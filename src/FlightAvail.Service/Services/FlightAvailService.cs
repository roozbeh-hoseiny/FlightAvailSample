using FlightAvail.Service.Abstraction;
using FlightAvail.Service.Models;
using Microsoft.Extensions.Logging;

namespace FlightAvail.Service.Services;

internal sealed class FlightAvailService : IFlightAvailService
{
    private readonly IFlightSupplierFactory _supplierFactory;
    private readonly ILogger<FlightAvailService> _logger;
    private static SuppliersEnum[]? _allSuppliers;
    private static SuppliersEnum[] AllSuppliers
    {
        get 
        {
            if (_allSuppliers is null)
                _allSuppliers = Enum.GetValues<SuppliersEnum>();
            return _allSuppliers;
        }
    }

    public FlightAvailService(IFlightSupplierFactory supplierFactory, ILogger<FlightAvailService> logger)
    {
        this._supplierFactory = supplierFactory;
        this._logger = logger;
    }

    public async ValueTask<IReadOnlyCollection<FlightInfo>> Avail(FlightAvailRequest request, CancellationToken cancellationToken)
    {
        List<FlightInfo> result = new();
        foreach (var sup in AllSuppliers)
        {
            if (!IsSupplierRequested(sup, request.Suppliers)) 
            {
                this._logger.LogInformation("'{supllier}' ignored", sup.ToString());
                continue; 
            }

            var supplierAdapter = this._supplierFactory.Create(sup);
            var adapterResult = await supplierAdapter!.Avail(request.FromDate, request.ToDate, cancellationToken).ConfigureAwait(false);
            this._logger.LogInformation("'{supllier}' response count :> {cnt}", sup.ToString(), (adapterResult?.Count ?? 0));
            
            if (!(adapterResult?.Any() ?? false)) continue;

            result.AddRange(adapterResult);

        }
        return result.AsReadOnly();
    }

    private static bool IsSupplierRequested(SuppliersEnum supplier, IEnumerable<SuppliersEnum>? src) => (src?.Any() ?? true) || src.Contains(supplier);
}

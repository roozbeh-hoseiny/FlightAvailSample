using FlightAvail.Service.DependencyInjection;
using FlightAvail.Service.ExtensionMethods;
using Microsoft.Extensions.Options;

namespace FlightAvail.Service.Suppliers.Supplier2.HttpProxy;

public abstract class Supplier2HttpProxy
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly FlightAvailServiceOptions _opts;

    public Supplier2HttpProxy(IHttpClientFactory httpClientFactory, IOptions<FlightAvailServiceOptions> opts)
    {
        this._httpClientFactory = httpClientFactory;
        this._opts = opts.Value;
    }

    protected async Task<IEnumerable<Supplier2FlightAvailResponse>> SupplierAvail(DateOnly from, DateOnly to, CancellationToken cancellationToken)
    {
        var endpoint = $"api/v1.0/periodicflight/?Id={this._opts.Supplier2Id}&FromDate={from.ToString("yyyy-MM-dd")}&ToDate={to.ToString("yyyy-MM-dd")}&site={this._opts.Supplier2SiteName}&type={this._opts.Supplier2FlightType}";

        using var client = this._httpClientFactory.CreateClient(SuppliersEnum.Supplier2.ToString());
        return await client.SendJsonRequest<Supplier2FlightAvailResponse[]>(
            endpoint,
            HttpMethod.Get,
            null,
            cancellationToken).ConfigureAwait(false) ?? Array.Empty<Supplier2FlightAvailResponse>();
    }
}

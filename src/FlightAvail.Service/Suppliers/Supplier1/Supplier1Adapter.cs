using FlightAvail.Service.Abstraction;
using FlightAvail.Service.DependencyInjection;
using FlightAvail.Service.Models;
using FlightAvail.Service.Suppliers.Supplier1.HttpProxy;
using Microsoft.Extensions.Options;

namespace FlightAvail.Service.Suppliers.Supplier1;

public sealed class Supplier1Adapter : Supplier1HttpProxy, IFlightSupplier
{
    public SuppliersEnum Supplier => SuppliersEnum.Supplier1;

    public Supplier1Adapter(IHttpClientFactory httpClientFactory, IOptions<FlightAvailServiceOptions> opts) : base(httpClientFactory, opts)
    {
    }

    public async ValueTask<IReadOnlyCollection<FlightInfo>> Avail(DateOnly fromDate, DateOnly toDate, CancellationToken cancellationToken)
    {
        var proxyResponse = await SupplierAvail(fromDate, toDate, cancellationToken);
        return Map(proxyResponse, Supplier.ToString()).ToArray().AsReadOnly();

    }

    private static FlightInfo[] Map(IEnumerable<Supplier1FlightAvailResponse> src, string suplier)
        => src.Select(f => new FlightInfo
        {
            FlightNumber = f.FlightNo,
            Departure = f.IataCodSource,
            Destination = f.IataCodDestinate,
            Airline = f.AirlineCode,
            DepartureDate = f.FlightDateTime,
            FlightClass = f.Class,
            Price = f.PriceView,
            Supplier = suplier
        }).ToArray();
}

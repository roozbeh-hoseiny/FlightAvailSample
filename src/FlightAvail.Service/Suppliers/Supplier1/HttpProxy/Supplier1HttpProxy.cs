using FlightAvail.Service.DependencyInjection;
using FlightAvail.Service.ExtensionMethods;
using Microsoft.Extensions.Options;

namespace FlightAvail.Service.Suppliers.Supplier1.HttpProxy;

public abstract class Supplier1HttpProxy
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly FlightAvailServiceOptions _opts;

    public Supplier1HttpProxy(IHttpClientFactory httpClientFactory, IOptions<FlightAvailServiceOptions> opts)
    {
        this._httpClientFactory = httpClientFactory;
        this._opts = opts.Value;
    }

    protected async Task<IEnumerable<Supplier1FlightAvailResponse>> SupplierAvail(DateOnly from, DateOnly to, CancellationToken cancellationToken)
    {
        var endpoint = "api/flights/ravisFlightList";
        using var client = this._httpClientFactory.CreateClient(SuppliersEnum.Supplier1.ToString());
        return await client.SendJsonRequest<Supplier1FlightAvailResponse[]>(
            endpoint, 
            HttpMethod.Post, 
            new 
            {
                CustomerId = this._opts.Supplier1CustomerId,
                Date1 = "14011224",
                Date2 = "14011228",
                Reservable = "1"
            }, 
            cancellationToken)
            .ConfigureAwait(false) ?? Array.Empty<Supplier1FlightAvailResponse>();
    }
}

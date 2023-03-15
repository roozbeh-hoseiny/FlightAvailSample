using FlightAvail.Service.Suppliers.Supplier1.HttpProxy;

namespace FlightAvailService.Samples.Shared.Fixtures;

internal static class Supplier1ProxyResponse
{
    public static IEnumerable<Supplier1FlightAvailResponse> Create()
    {
        return new Supplier1FlightAvailResponse[2]
        {
            new()
            {
                FlightNo         = FixtureHelper.FlightNumber1,
                IataCodSource    = FixtureHelper.Source,
                IataCodDestinate = FixtureHelper.Destination,
                Class            = FixtureHelper.FlightClass,
                AirlineCode      = FixtureHelper.Airline,
                FlightDateTime   = FixtureHelper.DepartureDate,
                PriceView        = FixtureHelper.Price,
            },
            new()
            {
                FlightNo         = FixtureHelper.FlightNumber2,
                IataCodSource    = FixtureHelper.Destination,
                IataCodDestinate = FixtureHelper.Source,
                Class            = FixtureHelper.FlightClass,
                AirlineCode      = FixtureHelper.Airline,
                FlightDateTime   = FixtureHelper.DepartureDate,
                PriceView        = FixtureHelper.Price,
            }
        };
    }
}

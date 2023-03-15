using FlightAvail.Service.Suppliers.Supplier2.HttpProxy;

namespace FlightAvailService.Samples.Shared.Fixtures;

internal static class Supplier2ProxyResponse
{
    public static IEnumerable<Supplier2FlightAvailResponse> Create()
    {
        return new Supplier2FlightAvailResponse[2]
        {
            new()
            {
                FlightNumber        = FixtureHelper.FlightNumber1,
                OriginIataCode      = FixtureHelper.Source,
                DestinationIataCode = FixtureHelper.Destination,
                BookingCode         = FixtureHelper.FlightClass,
                AirlineIataCode     = FixtureHelper.Airline,
                DepartureDateTime   = FixtureHelper.DepartureDate,
                TotalFareAdult      = FixtureHelper.Price,
            },
            new()
            {
                FlightNumber        = FixtureHelper.FlightNumber2,
                OriginIataCode      = FixtureHelper.Destination,
                DestinationIataCode = FixtureHelper.Source,
                BookingCode         = FixtureHelper.FlightClass,
                AirlineIataCode     = FixtureHelper.Airline,
                DepartureDateTime   = FixtureHelper.DepartureDate,
                TotalFareAdult      = FixtureHelper.Price,
            }
        };
    }
}

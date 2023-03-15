using FlightAvail.Service;
using FlightAvail.Service.Models;

namespace FlightAvailService.Samples.Shared.Fixtures;

internal static class AvailServiceResponse
{
    private static IEnumerable<FlightInfo> CreateFor(SuppliersEnum sup)
    {
        return new FlightInfo[2]
        {
            new()
            {
                FlightNumber  = FixtureHelper.FlightNumber1,
                Departure     = FixtureHelper.Source,
                Destination   = FixtureHelper.Destination,
                FlightClass   = FixtureHelper.FlightClass,
                Airline       = FixtureHelper.Airline,
                DepartureDate = FixtureHelper.DepartureDate,
                Price         = FixtureHelper.Price,
                Supplier      = sup.ToString()

            },
            new()
            {
                FlightNumber  = FixtureHelper.FlightNumber2,
                Departure     = FixtureHelper.Destination,
                Destination   = FixtureHelper.Source,
                FlightClass   = FixtureHelper.FlightClass,
                Airline       = FixtureHelper.Airline,
                DepartureDate = FixtureHelper.DepartureDate,
                Price         = FixtureHelper.Price,
                Supplier      = sup.ToString()
            }
        };
    }

    public static IEnumerable<FlightInfo> Create()
    {
        var result = new List<FlightInfo>();
        result.AddRange(CreateFor(SuppliersEnum.Supplier1));
        result.AddRange(CreateFor(SuppliersEnum.Supplier2));
        return result;
    }
}

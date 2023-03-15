using FlightAvail.Service.Models;

namespace FlightAvail.Service.Abstraction;

public interface IFlightAvailService
{
    ValueTask<IReadOnlyCollection<FlightInfo>> Avail(FlightAvailRequest request, CancellationToken cancellationToken);
}

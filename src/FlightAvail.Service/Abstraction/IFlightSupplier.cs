using FlightAvail.Service.Models;

namespace FlightAvail.Service.Abstraction;

public interface IFlightSupplier
{
    SuppliersEnum Supplier { get; }
    ValueTask<IReadOnlyCollection<FlightInfo>> Avail(DateOnly fromDate, DateOnly toDate, CancellationToken cancellationToken);
}

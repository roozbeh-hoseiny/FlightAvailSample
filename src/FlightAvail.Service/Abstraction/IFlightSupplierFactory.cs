namespace FlightAvail.Service.Abstraction;

public interface IFlightSupplierFactory
{
    IFlightSupplier? Create(SuppliersEnum supplier);
}
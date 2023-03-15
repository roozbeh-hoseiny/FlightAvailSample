using FlightAvail.Service;

namespace FlightAvailService.Sample1.SupplierRepository;

interface IFlightSupplierRepository
{
    void Add(SuppliersEnum supplier, Type t);
    Type Get(SuppliersEnum supplier);
}

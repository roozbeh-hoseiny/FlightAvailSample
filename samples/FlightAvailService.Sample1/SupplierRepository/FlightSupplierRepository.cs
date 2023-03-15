using FlightAvail.Service;

namespace FlightAvailService.Sample1.SupplierRepository;

class FlightSupplierRepository : IFlightSupplierRepository
{
    private Dictionary<string, Type> _dic = new(StringComparer.InvariantCultureIgnoreCase);

    public FlightSupplierRepository()
    {
        _dic = new Dictionary<string, Type>();
    }
    public void Add(SuppliersEnum supplier, Type t) => _dic.TryAdd(supplier.ToString(), t);

    public Type? Get(SuppliersEnum supplier)
    {
        if (_dic.TryGetValue(supplier.ToString(), out var t))
            return t;
        throw new Exception("Invalid supplier");
    }
}
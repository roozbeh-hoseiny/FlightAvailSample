namespace FlightAvail.Service.Models;

public sealed class FlightAvailRequest
{
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
    public IEnumerable<SuppliersEnum>? Suppliers { get; set; }
}

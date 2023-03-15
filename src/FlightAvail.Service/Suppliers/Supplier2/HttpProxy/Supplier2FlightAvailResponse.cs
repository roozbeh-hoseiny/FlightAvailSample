namespace FlightAvail.Service.Suppliers.Supplier2.HttpProxy;

public class Supplier2FlightAvailResponse
{
    public string OriginIataCode { get; set; } = "";
    public string DestinationIataCode { get; set; } = "";
    public DateTime DepartureDateTime { get; set; }
    public string FlightNumber { get; set; } = "";
    public string AirlineIataCode { get; set; } = "";
    public decimal TotalFareAdult { get; set; }
    public string BookingCode { get; set; } = "";
}

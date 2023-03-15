namespace FlightAvail.Service.Models;

public record FlightInfo
{
    public required string FlightNumber { get; set; }
    public required string Departure { get; set; }
    public required string Destination { get; set; }
    public required string Airline { get; set; }
    public required string FlightClass { get; set; }
    public required DateTime DepartureDate { get; set; }
    public required decimal Price { get; set; }
    public required string Supplier { get; set; }
}

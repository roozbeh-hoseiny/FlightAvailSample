namespace FlightAvail.Service.Suppliers.Supplier1.HttpProxy;

public class Supplier1FlightAvailResponse
{
    public string IataCodSource { get; set; } = "";
    public string IataCodDestinate { get; set; } = "";
    public string AirlineCode { get; set; } = "";
    public string FlightNo { get; set; } = "";
    public DateTime FlightDateTime { get; set; }
    public decimal PriceView { get; set; }
    public string Class { get; set; } = "";
}

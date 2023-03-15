using FlightAvail.Service.Abstraction;
class SampleInstance
{
    private readonly IFlightAvailService _availService;

    public SampleInstance(IFlightAvailService availService)
    {
        this._availService = availService;
    }
    public async Task Run()
    {
        var serviceResult = await this._availService.Avail(new() { 
            FromDate = DateOnly.FromDateTime(DateTime.Now),
            ToDate   = DateOnly.FromDateTime(DateTime.Now.AddDays(3))
        }, default);
        
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(serviceResult, new System.Text.Json.JsonSerializerOptions() { WriteIndented = true }));
    }
}
    

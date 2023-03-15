using Microsoft.Extensions.DependencyInjection;

namespace FlightAvail.Service.DependencyInjection;

public class FlightAvailServiceBuilder
{
    public IServiceCollection Services { get; }

    internal FlightAvailServiceBuilder(IServiceCollection services)
    {
        this.Services = services;
    }
}

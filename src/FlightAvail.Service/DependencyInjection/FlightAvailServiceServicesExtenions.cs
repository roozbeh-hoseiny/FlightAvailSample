using FlightAvail.Service.Abstraction;
using FlightAvail.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FlightAvail.Service.DependencyInjection;

public static class FlightAvailServiceServicesExtenions
{
    public static FlightAvailServiceBuilder AddFlightAvailService(this IServiceCollection services)
    {
        var builder = new FlightAvailServiceBuilder(services);

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped<IFlightAvailService, FlightAvailService>();

        return builder;
    }

    public static FlightAvailServiceBuilder AddFlightAvailService(this IServiceCollection services, Action<FlightAvailServiceOptions> opts)
    {
        var builder = AddFlightAvailService(services);

        builder.Services.Configure(opts);

        return builder;
    }
}

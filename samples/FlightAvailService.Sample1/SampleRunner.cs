using FlightAvail.Service.Abstraction;
using FlightAvail.Service.Suppliers.Supplier1;
using FlightAvail.Service.Suppliers.Supplier2;
using FlightAvailService.Sample1.SupplierFactories;
using FlightAvailService.Sample1.SupplierRepository;
using FlightAvailService.Samples.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

static class SampleRunner
{
    public static async Task Run(params string[]? args)
    {
        Console.Clear();
        var services = RegisterSampleService((args ?? new string[] { "1" })[0]);

        var serviceProvider = services.BuildServiceProvider();
        var sampleRunner = ActivatorUtilities.CreateInstance(serviceProvider, typeof(SampleInstance)) as SampleInstance;
        await sampleRunner!.Run();
    }

    private static IServiceCollection RegisterSampleService(string sampleType)
    {
        IServiceCollection services = new ServiceCollection();
        return sampleType.ToLower().Trim() switch { 
            "1" => services.RegisterSampleService<SampleSupplierFactory1>(),
            "2" => RegisterSample2(services),
            "3" => RegisterSample3(services),
            "4" => RegisterSample4(services),
            "5" => RegisterSample5(services),
            "6" => RegisterSample6(services),
            _   => services.RegisterSampleService<SampleSupplierFactory1>()
        };
    }
    private static IServiceCollection RegisterSample2(IServiceCollection services)
    {
        services.AddScoped<IFlightSupplier, Supplier1Adapter>();
        services.AddScoped<IFlightSupplier, Supplier2Adapter>();

        services.RegisterSampleService<SampleSupplierFactory2>();

        return services;
    }
    private static IServiceCollection RegisterSample3(IServiceCollection services)
    {
        services.AddScoped<Supplier1Adapter>();
        services.AddScoped<Supplier2Adapter>();

        services.RegisterSampleService<SampleSupplierFactory3>();

        return services;
    }
    private static IServiceCollection RegisterSample4(IServiceCollection services)
    {
        services.AddScoped<IFlightSupplier, Supplier1Adapter>();
        services.AddScoped<IFlightSupplier, Supplier2Adapter>();
        services.AddScoped<Supplier1Adapter>();
        services.AddScoped<Supplier2Adapter>();
        services.AddSingleton(sp => {
            IFlightSupplierRepository result = new FlightSupplierRepository();
            foreach (var s in sp.GetServices<IFlightSupplier>())
            {
                result.Add(s.Supplier, s.GetType());
            }
            return result;
        });
        services.RegisterSampleService<SampleSupplierFactory4>();

        return services;
    }
    private static IServiceCollection RegisterSample5(IServiceCollection services)
    {
        services.Scan(scan => scan
          .FromAssemblies(Assembly.GetAssembly(typeof(Supplier2Adapter))!)
              .AddClasses(classes => classes.AssignableTo<IFlightSupplier>(), publicOnly: false)
                  .AsSelfWithInterfaces()
                  .WithLifetime(ServiceLifetime.Scoped)
        );

        services.AddSingleton(sp => {
            IFlightSupplierRepository result = new FlightSupplierRepository();
            foreach (var s in sp.GetServices<IFlightSupplier>())
            {
                result.Add(s.Supplier, s.GetType());
            }
            return result;
        });
        services.RegisterSampleService<SampleSupplierFactory4>();

        return services;
    }
    private static IServiceCollection RegisterSample6(IServiceCollection services)
    {
        services.Scan(scan => scan
          .FromAssemblies(Assembly.GetAssembly(typeof(Supplier2Adapter))!)
              .AddClasses(classes => classes.AssignableTo<IFlightSupplier>(), publicOnly: false)
                  .AsSelfWithInterfaces()
                  .WithLifetime(ServiceLifetime.Scoped)
        );

        services.AddSingleton(sp => {
            IFlightSupplierRepository result = new FlightSupplierRepository();
            foreach (var s in sp.GetServices<IFlightSupplier>())
            {
                result.Add(s.Supplier, s.GetType());
            }
            return result;
        });
        services.RegisterSampleService<SampleSupplierFactory4>();

        return services;
    }
}
    

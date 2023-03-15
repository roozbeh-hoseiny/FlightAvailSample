using FlightAvail.Service;
using FlightAvail.Service.Abstraction;
using FlightAvail.Service.Suppliers.Supplier1;
using FlightAvail.Service.Suppliers.Supplier2;
using Microsoft.Extensions.DependencyInjection;

namespace FlightAvailService.Sample1.SupplierFactories;

/*
    This is similar to 'SampleSupplierFactory2', except that it uses a concrete class as a dependency to obtain the appropriate supplier from the DI container.
    For using this factory, we don't need to add "IFlightSupplier" as a service. We just need to add the concrete classes that implement the "IFlightSupplier" interface as services.
 */
internal sealed class SampleSupplierFactory3 : IFlightSupplierFactory
{
    private readonly IServiceProvider _serviceProvider;

    public SampleSupplierFactory3(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    public IFlightSupplier? Create(SuppliersEnum supplier) => supplier switch
    {
        SuppliersEnum.Supplier1 => this._serviceProvider.GetRequiredService<Supplier1Adapter>(),
        SuppliersEnum.Supplier2 => this._serviceProvider.GetRequiredService<Supplier2Adapter>(),
        _ => throw new Exception("Not implemented supplier")
    };
}

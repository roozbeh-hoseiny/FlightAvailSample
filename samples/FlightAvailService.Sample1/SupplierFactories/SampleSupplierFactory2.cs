using FlightAvail.Service;
using FlightAvail.Service.Abstraction;
using FlightAvail.Service.Suppliers.Supplier1;
using FlightAvail.Service.Suppliers.Supplier2;
using Microsoft.Extensions.DependencyInjection;

namespace FlightAvailService.Sample1.SupplierFactories;

/*
    In this factory, we are utilizing IServiceProvider and reflection to obtain the appropriate supplier from the DI container. 
    In my opinion, this is superior to 'SampleSupplierFactory1' since we don't have to inject all of the dependencies for the suppliers
 */
internal sealed class SampleSupplierFactory2 : IFlightSupplierFactory
{
    private readonly IServiceProvider _serviceProvider;

    public SampleSupplierFactory2(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    public IFlightSupplier? Create(SuppliersEnum supplier) => supplier switch
    {
        SuppliersEnum.Supplier1 => this._serviceProvider.GetServices<IFlightSupplier>().FirstOrDefault(x => x.GetType().IsAssignableTo(typeof(Supplier1Adapter))),
        SuppliersEnum.Supplier2 => this._serviceProvider.GetServices<IFlightSupplier>().FirstOrDefault(x => x.GetType().IsAssignableTo(typeof(Supplier2Adapter))),
        _ => throw new Exception("Not implemented supplier")
    };
}

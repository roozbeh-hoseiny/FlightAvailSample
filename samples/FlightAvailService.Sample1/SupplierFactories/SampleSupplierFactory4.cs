using FlightAvail.Service;
using FlightAvail.Service.Abstraction;
using FlightAvailService.Sample1.SupplierRepository;
using Microsoft.Extensions.DependencyInjection;

namespace FlightAvailService.Sample1.SupplierFactories;

/*
    This factory uses IServiceProvider to obtain the appropriate service from the DI Container and another service to get the type of the requested service.

    "IFlightSupplierRepository" is a service that holds all suppliers and their associated concrete classes. Therefore, when we implement a new supplier, we do not need to change this factory to obtain the newly implemented supplier service.

    To add "IFlightSupplierRepository" to the DI Container, we use the AddSingleton method. 
    When we request "IFlightSupplierRepository" for the first time, we obtain all "IFlightSupplier" services that are registered in the DI Container and add them to the SupplierRepository. 
    Then, whenever we want to create an "IFlightSupplier" using the "IFlightSupplierFactory", we obtain the type of the requested supplier from the "SupplierRepository" and then get the requested service from the DI Container using the IServiceProvider.

 */
internal sealed class SampleSupplierFactory4 : IFlightSupplierFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IFlightSupplierRepository _repo;

    public SampleSupplierFactory4(IServiceProvider serviceProvider, IFlightSupplierRepository repo)
    {
        this._serviceProvider = serviceProvider;
        this._repo = repo;
    }

    public IFlightSupplier? Create(SuppliersEnum supplier) => this._serviceProvider.GetRequiredService(this._repo.Get(supplier)) as IFlightSupplier;

}

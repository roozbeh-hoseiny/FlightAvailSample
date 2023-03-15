using AutoMapper;
using FlightAvail.Service;
using FlightAvail.Service.Abstraction;
using FlightAvail.Service.DependencyInjection;
using FlightAvail.Service.Suppliers.Supplier1;
using FlightAvail.Service.Suppliers.Supplier2;
using Microsoft.Extensions.Options;

namespace FlightAvailService.Sample1.SupplierFactories;

/*
    this is the simplest factory that creates IFlightSupplier.
    In my opinion, this is not a good factory because we need all the dependencies of all suppliers to create an appropriate supplier.
    Note that we have injected IMapper in the constructor, even though we don't need it in the Supplier1Adapter!
 */
internal sealed class SampleSupplierFactory1 : IFlightSupplierFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;
    private readonly IOptions<FlightAvailServiceOptions> _opts;

    public SampleSupplierFactory1(IHttpClientFactory httpClientFactory, IMapper mapper, IOptions<FlightAvailServiceOptions> opts)
    {
        _httpClientFactory = httpClientFactory;
        _mapper = mapper;
        _opts = opts;
    }

    public IFlightSupplier? Create(SuppliersEnum supplier) => supplier switch
    {
        SuppliersEnum.Supplier1 => new Supplier1Adapter(_httpClientFactory, _opts),
        SuppliersEnum.Supplier2 => new Supplier2Adapter(_httpClientFactory, _mapper, _opts),
        _ => throw new Exception("Not implemented supplier")
    };
}

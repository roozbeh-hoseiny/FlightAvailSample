using AutoMapper;
using FlightAvail.Service.Abstraction;
using FlightAvail.Service.DependencyInjection;
using FlightAvail.Service.Models;
using FlightAvail.Service.Suppliers.Supplier2.HttpProxy;
using Microsoft.Extensions.Options;

namespace FlightAvail.Service.Suppliers.Supplier2;

public class Supplier2Adapter : Supplier2HttpProxy, IFlightSupplier
{
    private readonly IMapper _mapper;

    public SuppliersEnum Supplier => SuppliersEnum.Supplier2;

    public Supplier2Adapter(IHttpClientFactory httpClientFactory, IMapper mapper, IOptions<FlightAvailServiceOptions> opts) : base(httpClientFactory, opts)
    {
        this._mapper = mapper;
    }

    public async ValueTask<IReadOnlyCollection<FlightInfo>> Avail(DateOnly fromDate, DateOnly toDate, CancellationToken cancellationToken)
    {
        var proxyResponse = await SupplierAvail(fromDate, toDate, cancellationToken);
        return this._mapper.Map<IEnumerable<Supplier2FlightAvailResponse>, List<FlightInfo>>(proxyResponse, 
            opts => opts.AfterMap((src, dest) => 
            {
                dest.ForEach(f => f.Supplier = this.Supplier.ToString());
            })).AsReadOnly();
    }
}


using FlightAvail.Service.Models;
using FlightAvail.Service.Suppliers.Supplier2.HttpProxy;

namespace FlightAvail.Service.Suppliers.Supplier2;

public sealed class Supplier2MapperProfile : AutoMapper.Profile
{
    public Supplier2MapperProfile()
    {
        this.CreateMap<Supplier2FlightAvailResponse, FlightInfo>()
            .ForMember(dest => dest.Departure    , opts => opts.MapFrom(x => x.OriginIataCode))
            .ForMember(dest => dest.Destination  , opts => opts.MapFrom(x => x.DestinationIataCode))
            .ForMember(dest => dest.FlightClass  , opts => opts.MapFrom(x => x.BookingCode))
            .ForMember(dest => dest.Airline      , opts => opts.MapFrom(x => x.AirlineIataCode))
            .ForMember(dest => dest.DepartureDate, opts => opts.MapFrom(x => x.DepartureDateTime))
            .ForMember(dest => dest.Price        , opts => opts.MapFrom(x => x.TotalFareAdult));
    }
}

using AutoMapper;
using Test.Data.ProviderOne;
using Test.Data.ProviderTwo;
using Test.Data.Search;
using Test.Data.Entities;

namespace Test.SearchService.AutoMapperProfiles
{
    public class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<SearchRequest, ProviderOneSearchRequest>()
                .ForMember(drt => drt.From, scr => scr.MapFrom(x => x.Origin))
                .ForMember(drt => drt.To, scr => scr.MapFrom(x => x.Destination))
                .ForMember(drt => drt.DateFrom, scr => scr.MapFrom(x => x.OriginDateTime))
                .ForMember(drt => drt.DateTo, scr => scr.MapFrom(x => x.Filters == null ? null : x.Filters.DestinationDateTime))
                .ForMember(drt => drt.MaxPrice, scr => scr.MapFrom(x => x.Filters == null ? null : x.Filters.MaxPrice));

            CreateMap<SearchRequest, ProviderTwoSearchRequest>()
                .ForMember(drt => drt.Departure, scr => scr.MapFrom(x => x.Origin))
                .ForMember(drt => drt.Arrival, scr => scr.MapFrom(x => x.Destination))
                .ForMember(drt => drt.DepartureDate, scr => scr.MapFrom(x => x.OriginDateTime))
                .ForMember(drt => drt.MinTimeLimit, scr => scr.MapFrom(x => x.Filters == null ? null : x.Filters.MinTimeLimit));

            CreateMap<ProviderTwoRoute, Test.Data.Entities.Route>()
                .ForMember(drt => drt.Origin, scr => scr.MapFrom(x => x.Departure))
                .ForMember(drt => drt.Destination, scr => scr.MapFrom(x => x.Arrival.Point))
                .ForMember(drt => drt.OriginDateTime, scr => scr.MapFrom(x => x.Departure.Date))
                .ForMember(drt => drt.DestinationDateTime, scr => scr.MapFrom(x => x.Arrival.Date))
                .ForMember(drt => drt.Price, scr => scr.MapFrom(x => x.Price))
                .ForMember(drt => drt.TimeLimit, scr => scr.MapFrom(x => x.TimeLimit));

            CreateMap<ProviderOneRoute, Test.Data.Entities.Route>()
                .ForMember(drt => drt.Origin, scr => scr.MapFrom(x => x.From))
                .ForMember(drt => drt.Destination, scr => scr.MapFrom(x => x.To))
                .ForMember(drt => drt.OriginDateTime, scr => scr.MapFrom(x => x.DateFrom))
                .ForMember(drt => drt.DestinationDateTime, scr => scr.MapFrom(x => x.DateTo))
                .ForMember(drt => drt.Price, scr => scr.MapFrom(x => x.Price))
                .ForMember(drt => drt.TimeLimit, scr => scr.MapFrom(x => x.TimeLimit));
        }
    }
}

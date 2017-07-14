using AutoMapper;
using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo
{
    public static class MappingConfiguration
    {
        static MappingConfiguration()
        {
            MapsComplete = false;
        }

        public static bool MapsComplete { get; set; }

        public static void CreateMaps()
        {
            Mapper.Initialize(cfg =>
            {                
                cfg.CreateMap<Performance, PerformanceDto>().MaxDepth(2).ReverseMap().MaxDepth(2);
                cfg.CreateMap<Price, PriceDto>().MaxDepth(2).ReverseMap().MaxDepth(2);
                cfg.CreateMap<Season, SeasonDto>().MaxDepth(2).ReverseMap().MaxDepth(2);
                cfg.CreateMap<Show, ShowDto>().MaxDepth(2).ReverseMap().MaxDepth(2);
                cfg.CreateMap<ShowPrice, ShowPriceDto>().MaxDepth(2).ReverseMap().MaxDepth(2);
                cfg.CreateMap<ShowType, ShowTypeDto>().MaxDepth(2).ReverseMap().MaxDepth(2);
            });
        }
    }
}

using AutoMapper;
using testDemo.Dto;
using testDemo.Models;

namespace testDemo.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Flight, FlightDto>();
            CreateMap<FlightDto, Flight>();
        }
    }
}

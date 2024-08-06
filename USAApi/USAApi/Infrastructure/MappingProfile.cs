using AutoMapper;
using USAApi.Models;

namespace USAApi.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<RoomEntity, Room>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate / 100.0m));

            //TODO Url.Link
        }
    }
}

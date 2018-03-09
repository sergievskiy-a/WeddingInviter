using AutoMapper;
using FamilySite.Data.Entites;
using FamilySite.Dtos.Location;
using FamilySite.Models;

namespace FamilySite.IoC.AutoMapperProfiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            // Get
            CreateMap<Location, BaseLocationDto>()
                .Include<Location, LocationDto>();

            CreateMap<Location, LocationDto>();

            //Create
            CreateMap<BaseLocationDto, LocationModel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .Include<CreateLocationDto, LocationModel>();

            CreateMap<CreateLocationDto, LocationModel>();

            CreateMap<LocationModel, Location>();

            //Update
            CreateMap<LocationDto, LocationModel>();
        }
    }
}

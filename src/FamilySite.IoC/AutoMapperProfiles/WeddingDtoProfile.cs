using AutoMapper;
using FamilySite.Data.Entites;
using FamilySite.Dtos.Wedding;
using FamilySite.Models;

namespace FamilySite.IoC.AutoMapperProfiles
{
    public class WeddingDtoProfile : Profile
    {
        public WeddingDtoProfile()
        {
            // Get
            CreateMap<Wedding, BaseWeddingDto>()
                .Include<Wedding, WeddingDto>();

            CreateMap<Wedding, WeddingDto>();

            //Update
            CreateMap<WeddingDto, WeddingModel>();

            CreateMap<WeddingModel, Wedding>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
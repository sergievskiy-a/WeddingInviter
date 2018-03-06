using AutoMapper;
using FamilySite.Data.Entites;
using FamilySite.Dtos.Invite;
using FamilySite.Models;

namespace FamilySite.IoC.AutoMapperProfiles
{
    public class InviteProfile : Profile
    {
        public InviteProfile()
        {
            // Get
            CreateMap<InviteModel, Invite>();
            CreateMap<Invite, BaseInviteDto>();

            //Create
            CreateMap<BaseInviteDto, InviteModel>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            //Update
            CreateMap<UpdateInviteDto, InviteModel>();
        }
    }
}


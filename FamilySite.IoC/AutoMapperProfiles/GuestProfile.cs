using System;
using AutoMapper;
using FamilySite.Data.Entites;
using FamilySite.Dtos.Guest;
using FamilySite.Models;

namespace FamilySite.IoC.AutoMapperProfiles
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            // Get
            CreateMap<GuestModel, Guest>();
            CreateMap<Guest, BaseGuestDto>();

            //Create
            CreateMap<BaseGuestDto, GuestModel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.InviteId, opt => opt.Ignore());

            //Update
            CreateMap<UpdateGuestDto, GuestModel>()
                .ForMember(x => x.InviteId, opt => opt.Ignore());
        }
    }
}

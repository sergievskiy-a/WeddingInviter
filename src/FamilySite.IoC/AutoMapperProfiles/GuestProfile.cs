﻿using AutoMapper;
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
            CreateMap<Guest, BaseGuestDto>()
                .Include<Guest, GetGuestDto>();

            CreateMap<Guest, GetGuestDto>();

            //Create
            CreateMap<BaseGuestDto, GuestModel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.InviteId, opt => opt.Ignore());

            CreateMap<GuestModel, Guest>();

            //Update
            CreateMap<UpdateGuestDto, GuestModel>()
                .ForMember(x => x.InviteId, opt => opt.Ignore());
        }
    }
}

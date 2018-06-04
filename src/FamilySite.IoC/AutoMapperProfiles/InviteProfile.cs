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
            CreateMap<Invite, BaseInviteDto>()
                .Include<Invite, GetInviteDto>();

            CreateMap<Invite, GetInviteDto>()
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.InviteAnswer));

            CreateMap<InviteAnswer, InviteAnswerDto>();

            //Create
            CreateMap<BaseInviteDto, InviteModel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .Include<CreateInviteDto, InviteModel>();

            CreateMap<CreateInviteDto, InviteModel>();

            CreateMap<InviteModel, Invite>()
                .ForMember(dest => dest.WeddingId, opt => opt.Ignore());

            CreateMap<InviteAnswerDto, InviteAnswerModel>()
                .ForMember(dest => dest.InviteId, opt => opt.Ignore());

            CreateMap<InviteAnswerModel, InviteAnswer>()
                .ForMember(src => src.Invite, opt => opt.Ignore());

            //Update
            CreateMap<UpdateInviteDto, InviteModel>();
        }
    }
}


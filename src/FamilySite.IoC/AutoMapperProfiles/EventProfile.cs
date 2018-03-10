using AutoMapper;
using FamilySite.Data.Entites;
using FamilySite.Dtos.Event;
using FamilySite.Models;

namespace FamilySite.IoC.AutoMapperProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            // Get
            CreateMap<Event, BaseEventDto>()
                .Include<Event, EventDto>();

            CreateMap<Event, EventDto>();

            //Create
            CreateMap<BaseEventDto, EventModel>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<EventModel, Event>()
                .ForMember(dest => dest.WeddingId, opt => opt.Ignore());

            //Update
            CreateMap<EventDto, EventModel>();
        }
    }
}
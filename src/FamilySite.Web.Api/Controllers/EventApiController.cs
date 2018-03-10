using AutoMapper;
using FamilySite.Dtos.Event;
using FamilySite.Models;
using FamilySite.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilySite.Web.Api.Controllers
{
    [Route("api/events")]
    public class EventApiController: Controller
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;

        public EventApiController(IEventService eventService, IMapper mapper)
        {
            this.eventService = eventService;
            this.mapper = mapper;
        }

        [HttpGet("all")]
        public IActionResult Get(string alias)
        {
            var inviteDtos = this.eventService.GetEvents<EventDto>();

            return Ok(inviteDtos);
        }

        [HttpPost, Authorize]
        public IActionResult Create([FromBody] BaseEventDto dto)
        {
            var model = this.mapper.Map<EventModel>(dto);
            var eventId = this.eventService.AddEvent(model);

            var result = this.eventService.GetEvent<EventDto>(eventId);

            return Ok(result);
        }

        [HttpPut, Authorize]
        public IActionResult Update([FromBody] EventDto  dto)
        {
            var model = this.mapper.Map<EventModel>(dto);
            this.eventService.UpdateEvent(model);

            var result = this.eventService.GetEvent<EventDto>(dto.Id);

            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult Delte(int id)
        {
            this.eventService.DeleteEvent(id);

            return NoContent();
        }
    }
}

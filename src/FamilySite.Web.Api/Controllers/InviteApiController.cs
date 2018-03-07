using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using FamilySite.Dtos.Guest;
using FamilySite.Dtos.Invite;
using FamilySite.Models;
using FamilySite.Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace FamilySite.Web.Api.Controllers
{
    [Route("api/invite")]
    public class InviteApiController : Controller
    {
        private readonly IInviteService inviteService;
        private readonly IGuestService guestService;
        private readonly IMapper mapper;

        public InviteApiController(IInviteService inviteService, IGuestService guestService, IMapper mapper)
        {
            this.inviteService = inviteService;
            this.guestService = guestService;
            this.mapper = mapper;
        }

        [HttpGet("{alias}")]
        public IActionResult Get(string alias)
        {
            var inviteDto = this.inviteService.GetInvite<GetInviteDto>(alias);

            return Ok(inviteDto);
        }

        [HttpPost, Authorize]
        public IActionResult Create([FromBody] CreateInviteDto dto)
        {
            var model = this.mapper.Map<InviteModel>(dto);
            var id = this.inviteService.AddInvite(model);

            var result = this.inviteService.GetInvite<GetInviteDto>(id);

            return Ok(result);
        }

        [HttpPut("{id}"), Authorize]
        public IActionResult Update(int id, [FromBody] UpdateInviteDto dto)
        {
            var model = this.mapper.Map<InviteModel>(dto);
            this.inviteService.UpdateInvite(model);

            var result = this.inviteService.GetInvite<GetInviteDto>(id);
            return Ok(new GetInviteDto
            {
                Id = id,
                Alias = dto.Alias,
                Description = dto.Description,
                Guests = new List<GetGuestDto>
                {
                    new GetGuestDto
                    {
                        Id = 1,
                        FirstName = "Ruslan",
                        LastName = "Kulyk",
                        FromGroom = true,
                        PhoneNumber = "093 888 89 99"
                    },
                    new GetGuestDto
                    {
                        Id = 2,
                        FirstName = "Natasha",
                        LastName = "Kulyk",
                        FromGroom = true,
                        PhoneNumber = "093 777 77 99"
                    }
                }
            });
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            this.inviteService.DeleteInvite(id);
            var result = this.inviteService.GetInvite<GetInviteDto>(id);

            return NoContent();
        }
    }
}
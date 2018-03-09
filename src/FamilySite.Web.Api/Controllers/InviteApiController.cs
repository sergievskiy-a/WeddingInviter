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
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            this.inviteService.DeleteInvite(id);

            return NoContent();
        }
    }
}
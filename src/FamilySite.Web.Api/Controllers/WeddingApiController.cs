using AutoMapper;
using FamilySite.Dtos.Event;
using FamilySite.Dtos.Wedding;
using FamilySite.Models;
using FamilySite.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilySite.Web.Api.Controllers
{
    [Route("api/wedding")]
    public class WeddingApiController : Controller
    {
        private readonly IWeddingService weddingService;
        private readonly IMapper mapper;

        public WeddingApiController(IWeddingService weddingService, IMapper mapper)
        {
            this.weddingService = weddingService;
            this.mapper = mapper;
        }

        [HttpGet("info")]
        public IActionResult GetInfo(string alias)
        {
            var weddingDto = this.weddingService.GetWedding<WeddingDto>();

            return Ok(weddingDto);
        }

        [HttpPut, Authorize]
        public IActionResult Update([FromBody] BaseWeddingDto dto)
        {
            var model = this.mapper.Map<WeddingModel>(dto);
            var result = this.weddingService.CreateOrUpdate<WeddingDto>(model);

            return Ok(result);
        }
    }
}

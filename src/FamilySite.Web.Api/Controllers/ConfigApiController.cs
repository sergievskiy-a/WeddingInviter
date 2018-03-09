using Microsoft.AspNetCore.Mvc;

namespace FamilySite.Web.Api.Controllers
{
    [Route("api/config")]
    public class ConfigApiController : Controller
    {
        [HttpGet("{code}")]
        public IActionResult Get(string code)
        {
            // TODO: Add Wedding entity, and add it to invite.

            return Ok();
        }
    }
}
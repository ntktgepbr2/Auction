using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(new {name = "Daniel"});
        }
    }
}

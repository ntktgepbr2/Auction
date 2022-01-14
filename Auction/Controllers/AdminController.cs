using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(new {name = "Daniel"});
        }
    }
}

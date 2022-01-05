using System.Collections.Generic;
using System.Security.Claims;
using Auction.Contracts.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            List<ItemDto> allItems = (List<ItemDto>)TempData["allItems"];

            return View(allItems);
        }
        [Authorize(Roles = "admin")]
        public IActionResult About()
        {

            return View();
        }
    }
}

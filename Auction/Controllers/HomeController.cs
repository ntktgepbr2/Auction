using System;
using System.Threading.Tasks;
using Auction.Business.Services.ItemLots;
using Auction.Domain.Models;
using Auction.Extensions;
using Auction.Helpers;
using Auction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemLotService _itemLotService;

        public HomeController(IItemLotService itemLotService)
        {
            _itemLotService = itemLotService;
        }

        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Index()
        {
            var allItems = await _itemLotService.GetAllItems();
            return View(allItems.ToDto());

        }

        [Authorize(Roles = "admin")]
        public IActionResult Administration(User userModel)
        {
            if (userModel.IsValid())
                    return View(userModel);

            return View();
        }

        public IActionResult About()
        {

            return View();
        }

        public IActionResult Error(ErrorDetails error)
        {
            return View(error);
        }
    }
}

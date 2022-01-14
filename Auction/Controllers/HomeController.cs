using System.Threading.Tasks;
using Auction.Business.Services.ItemLots;
using Auction.Domain.Models;
using Auction.Extensions;
using Auction.Helpers;
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
        public async Task<IActionResult> Administration(User user = null)
        {
            if (user.IsValid())
                return View(user);

            return View();
        }

        public IActionResult About()
        {

            return View();
        }
    }
}

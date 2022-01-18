using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Auction.Business.Services.ItemLots;
using Auction.Contracts.Items;
using Auction.Extensions;
using Auction.Business.Services.Users;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{
    [Authorize(Roles = "admin, user")]
    [Route("[controller]/[action]/{id}")]
    public class BidController : Controller
    {
        private readonly IItemLotService _itemLotService;
        private readonly IUserService _userService;

        public BidController(IItemLotService itemLotService, IUserService userService)
        {
            _itemLotService = itemLotService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItemByIdAsync(Guid id)
        {
            var item = await _itemLotService.GetItemById(id);
            return View(item.ToDto());

        }

        [HttpGet]
        public async Task<IActionResult> BidItemAsync(Guid Id, string errorMessage = null)
        {
            var item = await _itemLotService.GetItemById(Id);
                ViewBag.ErrorMessage = errorMessage;

                return View(item.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> BidItemAsync(BidItemRequest request)
        {
            if (!ModelState.IsValid) { return RedirectToAction("BidItemAsync", new { request.Id, errorMessage = "Invalid bid" }); }

                if (request.LastBid <= request.CurrentPrice) { return RedirectToAction("BidItemAsync", new { request.Id, errorMessage = $"Bid more then {request.CurrentPrice}" }); }

                var userEmail = HttpContext.User.Identity.Name;
                await _itemLotService.UpdateItemPrice(request.ToCommand(userEmail));

                return RedirectToAction("BidItemAsync", request.Id);
        }

    }
}

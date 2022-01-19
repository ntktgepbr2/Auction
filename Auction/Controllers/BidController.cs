using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Auction.Business.Contracts.Items;
using Auction.Business.Services.ItemLots;
using Auction.Contracts.Items;
using Auction.Extensions;
using Auction.Business.Services.Users;
using Auction.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{
    [Authorize(Roles = "admin, user")]
    [Route("[controller]/[action]/{id}")]
    public class BidController : Controller
    {
        private readonly IItemLotService _itemLotService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public BidController(IItemLotService itemLotService, IUserService userService, IMapper mapper)
        {
            _itemLotService = itemLotService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetItemByIdAsync(Guid id)
        {
            ItemLot item = await _itemLotService.GetItemById(id);
            return View(_mapper.Map<ItemDto>(item));

        }

        [HttpGet]
        public async Task<IActionResult> BidItemAsync(Guid Id, string errorMessage = null)
        {
            ItemLot item = await _itemLotService.GetItemById(Id);
            ViewBag.ErrorMessage = errorMessage;

            return View(_mapper.Map<ItemDto>(item));
        }

        [HttpPost]
        public async Task<IActionResult> BidItemAsync(BidItemRequest request)
        {
            if (!ModelState.IsValid) { return RedirectToAction("BidItemAsync", new { request.Id, errorMessage = "Invalid bid" }); }

            if (request.LastBid <= request.CurrentPrice) { return RedirectToAction("BidItemAsync", new { request.Id, errorMessage = $"Bid more then {request.CurrentPrice}" }); }
            await _itemLotService.UpdateItemPrice(_mapper.Map<UpdateItemPriceCommand>(request));

            return RedirectToAction("BidItemAsync", request.Id);
        }

    }
}

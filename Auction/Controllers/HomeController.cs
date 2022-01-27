using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Services.ItemLots;
using Auction.Contracts.Items;
using Auction.Contracts.Users;
using Auction.Domain.Models;
using Auction.Extensions;
using Auction.Helpers;
using Auction.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemLotService _itemLotService;
        private readonly IMapper _mapper;

        public HomeController(IItemLotService itemLotService, IMapper mapper)
        {
            _itemLotService = itemLotService;
            _mapper = mapper;
        }

        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Index()
        {
            var allItems = await _itemLotService.GetAllItems();
            return View(_mapper.Map<List<ItemDto>>(allItems));

        }

        [Authorize(Roles = "admin")]
        public IActionResult Administration(UserDto userModel)
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

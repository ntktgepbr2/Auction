using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Contracts.Items;
using Auction.Business.Exceptions;
using Auction.Business.Services.ItemLots;
using Auction.Contracts.Items;
using Auction.Domain.Models;
using Auction.Extensions;
using Auction.Business.Services.Users;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{
    [Authorize(Roles = "admin, user")]
    [Route("[controller]/[action]")]
    public class ItemLotController : Controller
    {
        private readonly IItemLotService _itemLotService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ItemLotController(IItemLotService itemLotService, IUserService userService, IMapper mapper)
        {
            _itemLotService = itemLotService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<ItemDto>>> GetAllUserItemsAsync(string name)
        {
            var items = await _itemLotService.GetAllUserItems(name);
            return View(_mapper.Map<List<ItemDto>>(items));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByIdAsync(Guid id)
        {
            ItemLot item = await _itemLotService.GetItemById(id);
            return View(_mapper.Map<ItemDto>(item));
        }

        [HttpGet()]
        public IActionResult CreateItemAsync()
        {
            return View();
        }

        [HttpPost()]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemRequest request)
        {
            if (ModelState.IsValid)
            {
                await _itemLotService.CreateItem(_mapper.Map<CreateItemCommand>(request));
                return RedirectToAction("GetAllUserItemsAsync","ItemLot", new {name = request.Email});
            }

            return View();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemToUpdateAsync(Guid Id)
        {
            ItemLot item = await _itemLotService.GetItemById(Id);
            return View(_mapper.Map<ItemDto>(item));
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> UpdateItemAsync(UpdateItemRequest request)
        {
            await _itemLotService.UpdateItem(_mapper.Map<UpdateItemCommand>(request));
            return RedirectToAction("GetAllUserItemsAsync", request.Name);
        }

        [HttpDelete("{id}")]
        public async Task DeleteItemAsync(Guid id)
        {
            await _itemLotService.DeleteItem(id);
        }
    }
}

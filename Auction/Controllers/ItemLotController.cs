using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Exceptions;
using Auction.Business.Services.ItemLots;
using Auction.Contracts.Items;
using Auction.Domain.Models;
using Auction.Extensions;
using Auction.Business.Services.Users;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{
    [Authorize(Roles = "admin, user")]
    [Route("[controller]/[action]")]
    public class ItemLotController : Controller
    {
        private readonly IItemLotService _itemLotService;
        private readonly IUserService _userService;

        public ItemLotController(IItemLotService itemLotService, IUserService userService)
        {
            _itemLotService = itemLotService;
            _userService = userService;
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyCollection<ItemLot>>> GetAllItemsAsync()
        {
            var allItems = await _itemLotService.GetAllItems();
            TempData["allItems"] = allItems.ToDto();

            return RedirectToAction("Index", "Home");   
        }

        [HttpGet()]
        public async Task<ActionResult<List<ItemDto>>> GetAllUserItemsAsync()
        {
            var userEmail = HttpContext.User.Identity.Name;

            var result = await _itemLotService.GetAllUserItems(userEmail);
            var itemDto = result.ToDto();
            //TempData["Items"] = itemDto;
            //TempData.Keep();

            return View(itemDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByIdAsync(Guid id)
        {
            var result = await _itemLotService.GetItemById(id);

            return View(result.ToDto());
        }

        [HttpGet()]
        public  IActionResult CreateItemAsync()
        {
            return View();
        }

        [HttpPost()]
        public async Task<ActionResult<ItemDto>>  CreateItemAsync(CreateItemRequest request)
        {
            var userEmail = HttpContext.User.Identity.Name; 

            var result = await _itemLotService.CreateItem(request.ToCommand(userEmail));
            var resultDto = result.ToDto();

            return CreatedAtAction(nameof(GetItemByIdAsync), new {id = resultDto.Id}, resultDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemToUpdateAsync(Guid Id)
        {
            return View((await _itemLotService.GetItemById(Id)).ToDto());
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> UpdateItemAsync(UpdateItemRequest request)
        {
            var result = await _itemLotService.UpdateItem(request.ToCommand());

            return RedirectToAction("GetAllUserItemsAsync");
        }

        [HttpDelete("{id}")]
        public async Task DeleteItemAsync(Guid id)
        {
           await _itemLotService.DeleteItem(id);
        }
    }
}

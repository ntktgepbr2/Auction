using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Auction.Business.Services.ItemLots;
using Auction.Contracts.Items;
using Auction.Domain.Models;
using Auction.Extensions;

namespace Auction.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/itemLot")]
    public class ItemLotController : Controller
    {
        private readonly IItemLotService _itemLotService;

        public ItemLotController(IItemLotService itemLotService)
        {
            _itemLotService = itemLotService;
        }

        [HttpGet()]
        public async Task<List<ItemLot>> GetAllItemsAsync()
        {
            return await _itemLotService.GetAllItems();
        }
        
        [HttpGet("{id}")]
        public async Task<ItemLot> GetItemByIdAsync(Guid id)
        {
            return await _itemLotService.GetItemById(id);
        }

        [HttpPost()]
        public async Task<ActionResult<ItemDto>>  CreateItemAsync([FromBody][Required]CreateItemRequest request)
        {

            var result = await _itemLotService.CreateItem(request.ToCommand());
            var resultDto = result.ToDto();

            return CreatedAtAction(nameof(GetItemByIdAsync), new {id = resultDto.Id}, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateItemAsync([FromBody][Required] UpdateItemRequest request)
        {
            var result = await _itemLotService.CreateItem(request.ToCommand());

            return result.ToDto();
        }

        [HttpDelete("{id}")]
        public async Task DeleteItemAsync(Guid id)
        {
           await _itemLotService.DeleteItem(id);
        }
    }
}

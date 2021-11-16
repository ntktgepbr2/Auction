using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Contracts.Items;
using Auction.Domain.Models;

namespace Auction.Business.Services.ItemLots
{
    public interface IItemLotService
    {
        public Task<List<ItemLot>> GetAllItems();

        public Task<ItemLot> GetItemById(Guid id);

        Task<ItemLot> CreateItem(UpdateItemCommand command);

        Task DeleteItem(Guid itemId);
    }
}

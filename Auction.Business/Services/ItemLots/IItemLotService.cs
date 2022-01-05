using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Contracts.Items;
using Auction.Domain.Models;

namespace Auction.Business.Services.ItemLots
{
    public interface IItemLotService
    {
        public Task<IReadOnlyCollection<ItemLot>> GetAllItems();
        public Task<IReadOnlyCollection<ItemLot>> GetAllUserItems(string email);

        public Task<ItemLot> GetItemById(Guid id);

        Task<ItemLot> CreateItem(CreateItemCommand command);
        Task<ItemLot> UpdateItem(UpdateItemCommand command);

        Task DeleteItem(Guid itemId);
    }
}

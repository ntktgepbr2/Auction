using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Contracts.Items;
using Auction.Domain.Models;

namespace Auction.Business.Services.ItemLots
{
    public interface IItemLotService
    {
        Task<IReadOnlyCollection<ItemLot>> GetAllItems();
        Task<IReadOnlyCollection<ItemLot>> GetAllUserItems(string email);
        Task<ItemLot> GetItemById(Guid id);
        Task<ItemLot> CreateItem(CreateItemCommand command);
        Task<ItemLot> UpdateItem(UpdateItemCommand command);
        Task UpdateItemPrice(UpdateItemPriceCommand command);
        Task DeleteItem(Guid itemId);
    }
}

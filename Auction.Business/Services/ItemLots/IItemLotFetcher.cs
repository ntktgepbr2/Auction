using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Domain.Models;

namespace Auction.Business.Services.ItemLots
{
    public interface IItemLotFetcher
    {
        public Task<List<ItemLot>> GetAllItems();
        public Task<ItemLot> GetItemById(Guid id);
    }
}
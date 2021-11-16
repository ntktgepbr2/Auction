using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Domain.Models;

namespace Auction.Data.Repositories
{
    public interface IItemLotRepository
    {
        Task<List<ItemLot>> GetItemsAsync();

         Task<ItemLot> GetItemByIdAsync(Guid itemLotId);

         Task CreateItemAsync(ItemLot item);

         Task UpdateItemAsync(ItemLot item);

         Task DeleteItemAsync(Guid itemLotId);


    }
}

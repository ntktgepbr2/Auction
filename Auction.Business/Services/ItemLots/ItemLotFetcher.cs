using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Exceptions;
using Auction.Data.Repositories;
using Auction.Domain.Models;

namespace Auction.Business.Services.ItemLots
{
    public class ItemLotFetcher : IItemLotFetcher
    {
        private readonly IItemLotRepository _itemLotRepository;

        public ItemLotFetcher(IItemLotRepository itemLotRepository)
        {
            _itemLotRepository = itemLotRepository;
        }


        public Task<List<ItemLot>> GetAllItems()
        {
            return _itemLotRepository.GetItemsAsync();
        }

        public Task<ItemLot> GetItemById(Guid id)
        {
            var result = _itemLotRepository.GetItemByIdAsync(id);

            return result ?? throw new EntityNotFoundException("Item not found");
        }
    }
}
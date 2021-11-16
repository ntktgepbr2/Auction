using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Contracts.Items;

namespace Auction.Business.Services.ItemLots
{
    public class ItemLotService : IItemLotService
    {
        private readonly IItemLotFetcher _itemLotFetcher;
        private readonly IItemLotUpdater _itemLotUpdater;
        private readonly IItemLotRemover _itemLotRemover;

        public ItemLotService(IItemLotFetcher itemLotFetcher, IItemLotUpdater itemLotUpdater, IItemLotRemover itemLotRemover)
        {
            _itemLotFetcher = itemLotFetcher;
            _itemLotUpdater = itemLotUpdater;
            _itemLotRemover = itemLotRemover;
        }

        public Task<List<ItemLot>> GetAllItems()
        {
            return _itemLotFetcher.GetAllItems();
        }

        public Task<ItemLot> GetItemById(Guid id)
        {
            return _itemLotFetcher.GetItemById(id);
        }

        public Task<ItemLot> CreateItem(UpdateItemCommand command)
        {
            return _itemLotUpdater.Update(command);
        }

        public Task DeleteItem(Guid itemId)
        {
            return _itemLotRemover.Delete(itemId);
        }
    }
}

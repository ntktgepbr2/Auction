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
        private readonly IItemRepository _itemRepository;

        public ItemLotFetcher(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }


        public Task<IReadOnlyCollection<ItemLot>> GetAllItems()
        {
            return _itemRepository.GetAll();
        }

        public Task<IReadOnlyCollection<ItemLot>> GetAllUserItems(string email)
        {
            return _itemRepository.GetAllUserLots(email);
        }

        public Task<ItemLot> GetItemById(Guid id)
        {
            var result = _itemRepository.GetEntity(id);

            return result ?? throw new EntityNotFoundException("Item not found");
        }
    }
}
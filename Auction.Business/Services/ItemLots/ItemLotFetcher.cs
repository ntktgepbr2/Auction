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


        public async Task<IReadOnlyCollection<ItemLot>> GetAllItems()
        {
            return await _itemRepository.GetAll();
        }

        public async Task<IReadOnlyCollection<ItemLot>> GetAllUserItems(string email)
        {
            return await _itemRepository.GetAllUserLots(email);
        }

        public async Task<ItemLot> GetItemById(Guid id)
        {
            var result = await _itemRepository.GetEntity(id);

            return result ?? throw new EntityNotFoundException("Item not found");
        }
    }
}
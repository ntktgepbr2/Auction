using System;
using System.Threading.Tasks;
using Auction.Data.Repositories;

namespace Auction.Business.Services.ItemLots
{
    public class ItemLotRemover : IItemLotRemover
    {
        private readonly IItemRepository _itemRepository;

        public ItemLotRemover(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task Delete(Guid itemId)
        {
            await _itemRepository.DeleteAsync(itemId);
        }
    }
}
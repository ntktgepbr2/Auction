using System;
using System.Threading.Tasks;
using Auction.Data.Repositories;

namespace Auction.Business.Services.ItemLots
{
    public class ItemLotRemover : IItemLotRemover
    {
        private readonly IItemLotRepository _itemLotRepository;

        public ItemLotRemover(IItemLotRepository itemLotRepository)
        {
            _itemLotRepository = itemLotRepository;
        }
        public async Task Delete(Guid itemId)
        {
            await _itemLotRepository.DeleteItemAsync(itemId);
        }
    }
}
using System.Threading.Tasks;
using Auction.Business.Contracts.Items;
using Auction.Domain.Models;

namespace Auction.Business.Services.ItemLots
{
    public interface IItemLotUpdater
    {
        Task<ItemLot> Update(UpdateItemCommand command);
        Task<ItemLot> Create(CreateItemCommand command);
    }
}
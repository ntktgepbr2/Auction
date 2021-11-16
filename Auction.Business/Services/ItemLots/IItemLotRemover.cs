using System;
using System.Threading.Tasks;

namespace Auction.Business.Services.ItemLots
{
    public interface IItemLotRemover
    {
        Task Delete(Guid itemId);
    }
}
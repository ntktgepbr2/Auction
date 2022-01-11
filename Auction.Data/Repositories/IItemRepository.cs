using Auction.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auction.Data.Repositories
{
    public interface IItemRepository : IRepositoryBase<ItemLot>
    {
        Task<IReadOnlyCollection<ItemLot>> GetAllUserLots(string email);
        Task UpdatePriceAsync();
    }
}
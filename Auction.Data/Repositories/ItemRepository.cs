using Auction.Data.DatabaseContext;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Repositories
{
    public class ItemRepository : RepositoryBase<ItemLot>, IItemRepository
    {
        public ItemRepository(AuctionDbContext context) : base(context)
        {

        }

        public async Task<IReadOnlyCollection<ItemLot>> GetAllUserLots(string email)
        {
             return await this.All.Where(i => i.User.Email == email).ToListAsync();
        }

        public async Task UpdatePriceAsync() => await UpdateContext();
    }
}
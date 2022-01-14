using System.Linq;
using Auction.Data.DatabaseContext;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Auction.Data.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(AuctionDbContext context) : base(context)
        {
        }

        public async Task<Role> GetRole(string name)
        {
            return await this.All.FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task UpdateUserContext() => await UpdateContext();
    }
}
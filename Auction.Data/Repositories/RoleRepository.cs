using System.Linq;
using Auction.Data.DatabaseContext;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Auction.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AuctionDbContext _context;
        public RoleRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<Role> GetRole(string name)
        {
            return await _context.Roles.Include(u=>u.Users).FirstOrDefaultAsync(r=>r.Name == name);
        }

        public async Task UpdateContext()
        {
            await _context.SaveChangesAsync();
        }
    }
}
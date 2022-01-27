using System;
using System.Linq;
using System.Text;
using Auction.Data.DatabaseContext;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Auction.Data.Querying;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Auction.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly AuctionDbContext _context;
        public UserRepository(AuctionDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserForLogin(UserHashedCredentials credentials)
        {
            var entity = this.All;
            var result = await this.All.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email == credentials.Email && u.Password == credentials.Hash);

            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var test = await this.All.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email == email);

            return test;
        }
        public async Task<UserHashedCredentials> GetSalt(string email)
        {
            var salt =  _context.Users.Where(u => u.Email == email).Select(u => new UserHashedCredentials
            {
                Salt = u.Salt,
                Hash = u.Password,
                Email = email,
            });

            return await salt.FirstOrDefaultAsync();
        }
        public async Task UpdateUserContext() => await UpdateContext();
    }
}
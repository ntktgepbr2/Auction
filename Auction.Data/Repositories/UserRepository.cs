﻿using System.Linq;
using Auction.Data.DatabaseContext;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Auction.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AuctionDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserForLogin(string name, string password)
        {
            var entity = this.All.ToList();
            var result = await this.All.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email == name && u.Password == password);

            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var test = await this.All.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email == email);

            return test;
        }

        public async Task UpdateUserContext() => await UpdateContext();
    }
}
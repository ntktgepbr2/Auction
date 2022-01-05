using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Domain.Models;

namespace Auction.Business.Services.Users
{
    public interface IUserFetcher
    {
        public Task<IReadOnlyCollection<User>> GetAllUsers();
        public Task<User> GetUserById(Guid id);
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserForLogin(string name, string password);
    }
}
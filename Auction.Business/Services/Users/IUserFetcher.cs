using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Business.Contracts.Users;
using Auction.Data.Querying;
using Auction.Domain.Models;

namespace Auction.Business.Services.Users
{
    public interface IUserFetcher
    {
        public Task<IReadOnlyCollection<User>> GetAllUsers();
        public Task<User> GetUserById(Guid id);
        public Task<User> GetUserByEmail(string email);
        public Task<UserHashedCredentials> GetSalt(string email);
        public Task<User> GetUserForLogin(UserHashedCredentials credentials);
    }
}
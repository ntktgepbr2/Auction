using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Business.Contracts.Users;
using Auction.Data.Querying;
using Auction.Domain.Models;

namespace Auction.Business.Services.Users
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<User>> GetAllUsers();

        Task<User> GetForLogin(UserHashedCredentials credentials);

        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);

        Task<User> CreateUser(CreateUserCommand command);
        Task<User> UpdateUser(UpdateUserCommand command);
        Task<UserHashedCredentials> GetSalt(string email);
        Task DeleteUser(Guid itemId);
        Task UpdateUserContext();
    }
}

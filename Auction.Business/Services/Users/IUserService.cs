using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Contracts.Users;
using Auction.Domain.Models;

namespace Auction.Business.Services.Users
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<User>> GetAllUsers();

        Task<User> GetForLogin(string name, string password);

        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);

        Task<User> CreateUser(UpdateUserCommand command);

        Task DeleteUser(Guid itemId);
    }
}

using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Contracts.Users;

namespace Auction.Business.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserFetcher _userFetcher;
        private readonly IUserUpdater _userUpdater;
        private readonly IUserRemover _userRemover;

        public UserService(IUserFetcher userFetcher, IUserUpdater userUpdater, IUserRemover userRemover)
        {
            _userFetcher = userFetcher;
            _userUpdater = userUpdater;
            _userRemover = userRemover;
        }

        public Task<IReadOnlyCollection<User>> GetAllUsers()
        {
            return _userFetcher.GetAllUsers();
        }

        public Task<User> GetUserById(Guid id)
        {
            return _userFetcher.GetUserById(id);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _userFetcher.GetUserByEmail(email);
        }

        public Task<User> GetForLogin(string name, string password)
        {
            return _userFetcher.GetUserForLogin(name, password);
        }

        public Task<User> CreateUser(UpdateUserCommand command)
        {
            return _userUpdater.Update(command);
        }

        public Task DeleteUser(Guid userId)
        {
            return _userRemover.Delete(userId);
        }
    }
}

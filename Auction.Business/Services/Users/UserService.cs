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

        public async Task<IReadOnlyCollection<User>> GetAllUsers()
        {
            return await _userFetcher.GetAllUsers();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _userFetcher.GetUserById(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userFetcher.GetUserByEmail(email);
        }

        public async Task<User> GetForLogin(string name, string password)
        {
            return await _userFetcher.GetUserForLogin(name, password);
        }

        public async Task<User> CreateUser(UpdateUserCommand command)
        {
            return await _userUpdater.Update(command);
        }

        public async Task DeleteUser(Guid userId)
        {
            await _userRemover.Delete(userId);
        }

        public async Task UpdateUserContext()
        {
            await _userUpdater.UpdateUserContext();
        }
    }
}

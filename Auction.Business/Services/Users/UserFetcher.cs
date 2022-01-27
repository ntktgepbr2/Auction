using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Business.Contracts.Users;
using Auction.Business.Exceptions;
using Auction.Data.Querying;
using Auction.Data.Repositories;
using Auction.Domain.Models;

namespace Auction.Business.Services.Users
{
    public class UserFetcher : IUserFetcher
    {
        private readonly IUserRepository _userRepository;

        public UserFetcher(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<IReadOnlyCollection<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var result = await _userRepository.GetEntity(id);
            return result ?? throw new EntityNotFoundException("User not found");
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _userRepository.GetUserByEmail(email);

            return result ?? throw new EntityNotFoundException("User not found");
        }

        public async Task<User> GetUserForLogin(UserHashedCredentials credentials)
        {
            var result = await _userRepository.GetUserForLogin(credentials);

            return result;
        }

        public async Task<UserHashedCredentials> GetSalt(string email)
        {
            return await _userRepository.GetSalt(email);
        }
    }
}
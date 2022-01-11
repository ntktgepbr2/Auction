using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Exceptions;
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

        public async Task<User> GetUserForLogin(string name, string password)
        {
            var result = await _userRepository.GetUserForLogin(name, password);

            return result;
        }
    }
}
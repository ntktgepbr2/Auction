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


        public Task<IReadOnlyCollection<User>> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public Task<User> GetUserById(Guid id)
        {
            var result = _userRepository.GetEntity(id);

            return result ?? throw new EntityNotFoundException("User not found");
        }

        public Task<User> GetUserByEmail(string email)
        {
            var result = _userRepository.GetUserByEmail(email);

            return result ?? throw new EntityNotFoundException("User not found");
        }

        public Task<User> GetUserForLogin(string name, string password)
        {
            var result = _userRepository.GetUserForLogin(name, password);

            return result;
        }
    }
}
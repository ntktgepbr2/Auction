using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Auction.Business.Contracts.Users;
using Auction.Data.Repositories;
using Auction.Domain.Models;

namespace Auction.Business.Services.Users
{
    public class UserUpdater : IUserUpdater
    {

        private readonly IUserRepository _userRepository;

        public UserUpdater(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Create(UpdateUserCommand command)
        {

            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email,
                Password = command.Password
            };
            user.Roles.Add(new Role() { Name = "user" });
            await _userRepository.AddAsync(user);

            return user;
        }

        public async Task<User> Update(UpdateUserCommand command)
        {
            User user = await _userRepository.GetEntity(command.Id);
            UpdateEntity(user, command);
            await _userRepository.UpdateAsync(user);

            return user;
        }

        public async Task UpdateUserContext()
        {
            await _userRepository.UpdateUserContext();
        }

        private static User UpdateEntity(User User, UpdateUserCommand command)
        {
            User.Name = command.Name;

            return User;
        }
    }
}
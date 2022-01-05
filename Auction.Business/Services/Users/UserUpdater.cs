using System;
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

        public async Task<User> Update(UpdateUserCommand command)
        {
            User user;

            if (command.IsCreation)
            {
                user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = command.Name,
                    Email = command.Email,
                    Password = command.Password,
                    RoleId = 2,
                };
                await _userRepository.AddAsync(user);

                return user;
            }

            user = await _userRepository.GetEntity(command.Id);
            UpdateEntity(user, command);
            await _userRepository.UpdateAsync(user);

            return user;
        }

        private static User UpdateEntity(User User, UpdateUserCommand command)
        {
            User.Name = command.Name;

            return User;
        }
    }
}
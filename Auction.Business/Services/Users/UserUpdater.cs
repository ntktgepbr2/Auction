using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Auction.Business.Contracts.Users;
using Auction.Business.Services.Roles;
using Auction.Data.Repositories;
using Auction.Domain.Models;

namespace Auction.Business.Services.Users
{
    public class UserUpdater : IUserUpdater
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoleService _roleService;

        public UserUpdater(IUserRepository userRepository, IRoleService roleService)
        {
            _userRepository = userRepository;
            _roleService = roleService;
        }

        public async Task<User> Create(CreateUserCommand command)
        {

            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email,
                Password = command.Password,
                Salt = command.Salt
            };
            string defaultRole = "user";
            Role role = await _roleService.GetRole(defaultRole);
            user.Roles.Add(role);
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
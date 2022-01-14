using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Contracts.Users;
using Auction.Business.Services.Users;
using Auction.Data.Repositories;

namespace Auction.Business.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task DeleteRole(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Role>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetRole(string name)
        {
            return await _roleRepository.GetRole(name);
        }

        public Task UpdateUserContext()
        {
            throw new NotImplementedException();
        }
    }
}

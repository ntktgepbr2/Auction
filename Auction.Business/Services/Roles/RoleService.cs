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

        public async Task<Role> GetRole(string name)
        {
            return await _roleRepository.GetRole(name);
        }

        public async Task UpdateUserContext()
        {
           await _roleRepository.UpdateContext();
        }
    }
}

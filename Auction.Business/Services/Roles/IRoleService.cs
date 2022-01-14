using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Business.Contracts.Users;
using Auction.Domain.Models;

namespace Auction.Business.Services.Roles
{
    public interface IRoleService
    {
        Task<IReadOnlyCollection<Role>> GetAllRoles();

        Task<Role> GetRole(string name);

        Task DeleteRole(string name);
        Task UpdateUserContext();
    }
}

using Auction.Domain.Models;
using System.Threading.Tasks;

namespace Auction.Data.Repositories
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        Task<Role> GetRole(string name);
        Task UpdateUserContext();
    }
}
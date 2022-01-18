using Auction.Domain.Models;
using System.Threading.Tasks;

namespace Auction.Data.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRole(string name);
        Task UpdateContext();
    }
}
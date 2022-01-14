using Auction.Domain.Models;
using System.Threading.Tasks;

namespace Auction.Data.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserForLogin(string name, string password);
        Task<User> GetUserByEmail(string email);
        Task UpdateUserContext();
    }
}
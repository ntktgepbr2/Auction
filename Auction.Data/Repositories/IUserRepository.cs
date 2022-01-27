using System.Linq;
using Auction.Domain.Models;
using System.Threading.Tasks;
using Auction.Data.Querying;

namespace Auction.Data.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserForLogin(UserHashedCredentials credentials);
        Task<User> GetUserByEmail(string email);
        Task<UserHashedCredentials> GetSalt(string email);
        Task UpdateUserContext();
    }
}
using System.Threading.Tasks;
using Auction.Data.Querying;

namespace Auction.Helpers
{
    public interface IPasswordValidator
    {
        Task<UserHashedCredentials> ValidatePassword(string email, string password);
        UserHashedCredentials HashPassword(string email, string password);
    }
}

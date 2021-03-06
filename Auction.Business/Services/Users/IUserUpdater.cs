using System.Threading.Tasks;
using Auction.Business.Contracts.Users;
using Auction.Domain.Models;

namespace Auction.Business.Services.Users
{
    public interface IUserUpdater
    {
        Task<User> Update(UpdateUserCommand command);
        Task<User> Create(CreateUserCommand command);
        Task UpdateUserContext();
    }
}
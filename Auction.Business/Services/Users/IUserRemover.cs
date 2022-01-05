using System;
using System.Threading.Tasks;

namespace Auction.Business.Services.Users
{
    public interface IUserRemover
    {
        Task Delete(Guid userId);
    }
}
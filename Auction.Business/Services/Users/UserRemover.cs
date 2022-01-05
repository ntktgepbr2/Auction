using System;
using System.Threading.Tasks;
using Auction.Data.Repositories;

namespace Auction.Business.Services.Users
{
    public class UserRemover : IUserRemover
    {
        private readonly IUserRepository _userRepository;

        public UserRemover(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Delete(Guid userId)
        {
            await _userRepository.DeleteAsync(userId);
        }
    }
}
using Auction.Business.Contracts.Users;
using Auction.Models;

namespace Auction.Extensions
{
    public static class UpdateUserCommandExtension
    {
        public static UpdateUserCommand LoginModelToCommand(this UserRegisterModel model)
        {
            return new UpdateUserCommand()
            {
                Name = model.Email,
                Email = model.Email,
                Password = model.Password,
                IsCreation = true,
            };
        }
    }
}

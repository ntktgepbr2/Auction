using System;

namespace Auction.Business.Contracts.Users
{
    public class CreateUserCommand : BaseUserCommand
    {
        public string Salt { get; set; }
    }
}
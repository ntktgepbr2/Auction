using System;

namespace Auction.Business.Contracts.Users
{
    public class UpdateUserCommand : BaseUserCommand
    {
        public Guid Id { get; set; }
    }
}
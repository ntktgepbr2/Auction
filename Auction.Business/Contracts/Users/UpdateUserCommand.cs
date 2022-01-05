using System;

namespace Auction.Business.Contracts.Users
{
    public class UpdateUserCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsCreation { get; set; }
    }
}
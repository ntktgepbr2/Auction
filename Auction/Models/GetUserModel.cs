using System.Collections.Generic;
using Auction.Contracts.Users;
using Auction.Domain.Models;

namespace Auction.Models
{
    public class GetUserModel
    {
        public GetUserRequest Request { get; set; }
        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Auction.Domain.Models
{
    public record Role
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}

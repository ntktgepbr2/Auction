using System.Collections.Generic;

namespace Auction.Domain.Models
{
    public record Role : DomainEntity
    {
        public ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}

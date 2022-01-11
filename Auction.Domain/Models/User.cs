using System.Collections.Generic;

namespace Auction.Domain.Models
{
    public record User : DomainEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<ItemLot> ItemLots { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
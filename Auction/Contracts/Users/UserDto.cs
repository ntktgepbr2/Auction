using System.Collections.Generic;
using Auction.Contracts.Items;
using Auction.Domain.Models;

namespace Auction.Contracts.Users
{
    public class UserDto : BaseDto
    {
        public ICollection<ItemDto> ItemLots { get; set; }
        public ICollection<Role> Roles { get; set; }
        public UserDto()
        {
            Roles = new List<Role>();
            ItemLots = new List<ItemDto>();
        }
    }
}

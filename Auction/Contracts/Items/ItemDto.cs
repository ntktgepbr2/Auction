using System;

namespace Auction.Contracts.Items
{
    public class ItemDto : BaseDto
    {
        public string Description { get; set; }

        public decimal StartedPrice { get; init; }

        public decimal CurrentPrice { get; set; }
    }
}

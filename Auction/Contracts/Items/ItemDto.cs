using System;

namespace Auction.Contracts.Items
{
    public class ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal StartedPrice { get; init; }

        public decimal CurrentPrice { get; set; }
    }
}
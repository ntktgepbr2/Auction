using System;

namespace Auction.Domain.Models
{
    public record ItemLot
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartedPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
using System;

namespace Auction.Domain.Models
{
    public record ItemLot : DomainEntity
    {
        public string Description { get; set; }
        public decimal StartedPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
        public User User { get; set; }
    }
}
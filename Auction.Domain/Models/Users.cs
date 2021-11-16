using System;

namespace Auction.Domain.Models
{
    public record Users
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
    }
}
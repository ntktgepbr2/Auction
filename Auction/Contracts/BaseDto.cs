using System;

namespace Auction.Contracts
{
    public class BaseDto
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
    }
}

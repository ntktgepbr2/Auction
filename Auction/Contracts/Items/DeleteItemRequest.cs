using System;

namespace Auction.Contracts.Items
{
    public class DeleteItemRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

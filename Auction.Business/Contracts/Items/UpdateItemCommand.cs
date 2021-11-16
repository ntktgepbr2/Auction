using System;

namespace Auction.Business.Contracts.Items
{
    public class UpdateItemCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal StartedPrice { get; init; }

        public decimal CurrentPrice { get; set; }

        public bool IsCreation { get; set; }
    }
}
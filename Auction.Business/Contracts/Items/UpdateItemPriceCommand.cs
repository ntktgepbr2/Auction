using System;

namespace Auction.Business.Contracts.Items
{
    public class UpdateItemPriceCommand
    {
        public Guid Id { get; set; }
        public decimal LastBid { get; set; }
        public string UserName { get; set; }
    }
}
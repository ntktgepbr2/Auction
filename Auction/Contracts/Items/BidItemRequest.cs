using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Contracts.Items
{
    public class BidItemRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Range(1, 99999999, ErrorMessage = "Should be between 1 and 99999999")]
        public decimal LastBid { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Contracts.Items
{
    public class UpdateItemRequest
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal StartedPrice { get; init; }

        public decimal CurrentPrice { get; set; }
    }
}
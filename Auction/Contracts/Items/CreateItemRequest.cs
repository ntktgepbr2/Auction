﻿using System.ComponentModel.DataAnnotations;
using Auction.Domain.Models;

namespace Auction.Contracts.Items
{
    public class CreateItemRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public decimal StartedPrice { get; init; }

        public decimal CurrentPrice { get; set; }
        public User User { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Domain.Models
{
    public abstract record DomainEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
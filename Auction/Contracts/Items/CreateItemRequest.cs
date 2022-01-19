using System.ComponentModel.DataAnnotations;
using Auction.Domain.Models;

namespace Auction.Contracts.Items
{
    public class CreateItemRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Started price is required")]
        [Range(1, 99999999, ErrorMessage = "Should be between 1 and 99999999")]
        public decimal? StartedPrice { get; init; }
        [Required(ErrorMessage = "Current price is required")]
        [Range(1, 99999999, ErrorMessage = "Should be between 1 and 99999999")]
        public decimal? CurrentPrice { get; set; }
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using Auction.Contracts.Items;

namespace Auction.Helpers
{
    public class BidValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var request =(BidItemRequest) validationContext.ObjectInstance;
            if (value == null) return new ValidationResult("Invalid bid");
            if (request.LastBid <= request.CurrentPrice) return new ValidationResult($"Bid more then { request.CurrentPrice }");
            

            return ValidationResult.Success; 
        }
    }
}

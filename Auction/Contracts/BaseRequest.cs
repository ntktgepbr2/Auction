using System.ComponentModel.DataAnnotations;

namespace Auction.Contracts
{
    public class BaseRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}

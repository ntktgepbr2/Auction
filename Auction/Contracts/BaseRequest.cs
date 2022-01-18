using System.ComponentModel.DataAnnotations;

namespace Auction.Contracts
{
    public class BaseRequest
    {
        [Required(ErrorMessage = "User name is required")]
        public string Name { get; set; }
    }
}

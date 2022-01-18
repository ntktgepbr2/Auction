namespace Auction.Contracts.Roles
{
    public class AddUserRoleRequest : BaseRequest
    {
        public string[] Roles { get; set; }
    }
}

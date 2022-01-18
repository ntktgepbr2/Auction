namespace Auction.Contracts.Roles
{
    public class RemoveUserRoleRequest : BaseRequest
    {
        public string[] Roles { get; set; }
    }
}

namespace Auction.Data.Querying
{
    public struct UserHashedCredentials
    {
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Email { get; set; }
    }
}

namespace Auction.Data.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; }

        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        /// <summary>Gets the connection string.</summary>
        /// <value>The connection string.</value>
        public string ConnectionString =>  $"mongodb://{User}:{Password}@{Host}:{Port}";

    }
}
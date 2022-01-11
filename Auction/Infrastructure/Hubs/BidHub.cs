using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace Auction.Infrastructure.Hubs
{
    public class BidHub : Hub
    {
        public async Task Send(string bidPrice, string currentPrice)
        {
            if (Decimal.Parse(bidPrice) > Decimal.Parse(currentPrice))
            {
                await this.Clients.Others.SendAsync("Receive", bidPrice);
            }

        }
    }
}

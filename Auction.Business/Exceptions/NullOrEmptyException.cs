using System;

namespace Auction.Business.Exceptions
{
    public class NullOrEmptyException : Exception
    {
        public NullOrEmptyException(string message)
        :base(message)
        {
            
        }
    }
}
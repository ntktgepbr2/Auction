﻿using System;

namespace Auction.Business.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public  EntityNotFoundException (string message)
        :base(message)
        {
        }
    }
}
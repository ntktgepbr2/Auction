﻿using System;

namespace Auction.Business.Contracts.Users
{
    public class BaseUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Auction.Contracts;
using Auction.Contracts.Items;
using Auction.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace Auction.Helpers
{
    public static class ModelValidator
    {

        public static bool IsValid(this BaseDto model)
        {
            if (model.Name == null) return false;
            return true;
        }


    }
}

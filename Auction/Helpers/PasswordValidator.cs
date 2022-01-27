using System.Threading.Tasks;
using Auction.Business.Services.Users;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Auction.Data.Querying;
using Auction.Exceptions;
using Auction.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Auction.Helpers
{
    public class PasswordValidator : IPasswordValidator
    {
        private readonly IUserService _userService;

        public PasswordValidator(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserHashedCredentials> ValidatePassword(string email, string password)
        {
            var credentials = await _userService.GetSalt(email);
            byte[] saltBytes = Convert.FromBase64String(credentials.Salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                saltBytes,
                KeyDerivationPrf.HMACSHA256,
                100000,
                256 / 8));

            if (hashed == credentials.Hash) return (credentials);
            return default;
        }

        public UserHashedCredentials HashPassword(string email, string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                100000,
                256 / 8));

            return new UserHashedCredentials()
            {
                Salt = Convert.ToBase64String(salt),
                Hash = hashed,
                Email = email
            };
        }
    }
}

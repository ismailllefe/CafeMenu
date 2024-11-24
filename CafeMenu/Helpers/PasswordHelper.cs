using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CafeMenu.Helpers
{
    public static class PasswordHelper
    {
        public static string GenerateSalt()
        {
            var buffer = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combined = Encoding.UTF8.GetBytes(password + salt);
                return Convert.ToBase64String(sha256.ComputeHash(combined));
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var enteredHash = HashPassword(enteredPassword, storedSalt);
            return enteredHash == storedHash;
        }
    }
}
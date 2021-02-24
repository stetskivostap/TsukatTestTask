using System;
using System.Security.Cryptography;
using System.Text;

namespace DataAccessLayer.Helpers
{
    public static class Hash
    {
        public static string HashText(string text, string salt)
        {
            var hasher = new SHA1CryptoServiceProvider();
            var hashedBytes = hasher.ComputeHash(Encoding.UTF8.GetBytes($"{text}{salt}"));
            hasher.Clear();
            return Convert.ToBase64String(hashedBytes);
        }

        public static bool VerifyHashedPassword(string text, string passHashed, string salt)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(passHashed))
            {
                return false;
            }
            else
            {
                var check = Hash.HashText(text, salt);
                return check.Equals(passHashed);
            }
        }
    }
}

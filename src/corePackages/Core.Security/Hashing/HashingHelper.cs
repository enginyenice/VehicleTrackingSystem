using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Hashing
{
    public class HashingHelper
    {
        public static string HashPassword(string password)
        {
            string passwordHash = "";
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
            return passwordHash;
        }
    }
}
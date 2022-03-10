/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using System.Security.Cryptography;
using System.Text;

namespace Core.Security.Hashing
{
    public class HashingHelper
    {
        #region Methods

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

        #endregion Methods
    }
}
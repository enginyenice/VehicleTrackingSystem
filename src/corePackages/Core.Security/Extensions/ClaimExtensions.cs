/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using System.Security.Claims;

namespace Core.Security.Extensions
{
    public static class ClaimExtensions
    {
        #region Methods

        public static void AddNameIdentifier(this ICollection<Claim> claims, int id)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
        }

        public static void AddUsername(this ICollection<Claim> claims, string username)
        {
            claims.Add(new Claim(ClaimTypes.Name, username));
        }

        #endregion Methods
    }
}
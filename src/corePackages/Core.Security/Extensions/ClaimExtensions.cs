using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddUsername(this ICollection<Claim> claims, string username)
        {
            claims.Add(new Claim(ClaimTypes.Name, username));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, int id)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
        }
    }
}
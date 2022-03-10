/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Security.Encryption
{
    public class CreateSecurityKeyHelper
    {
        #region Methods

        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }

        #endregion Methods
    }
}
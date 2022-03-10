/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Microsoft.IdentityModel.Tokens;

namespace Core.Security.Encryption
{
    public static class SigningCredentialsHelper
    {
        #region Methods

        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }

        #endregion Methods
    }
}
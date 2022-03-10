/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Core.Security.Entities;

namespace Core.Security.Jwt
{
    public interface ITokenHelper
    {
        #region Methods

        AccessToken CreateToken(User user);

        #endregion Methods
    }
}
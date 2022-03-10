/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace Core.Security.Entities
{
    public class AccessToken
    {
        #region Properties

        public DateTime Expiration { get; set; }
        public string Token { get; set; }

        #endregion Properties
    }
}
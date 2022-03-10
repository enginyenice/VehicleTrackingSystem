/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace Core.Security.Entities
{
    public class TokenOption
    {
        #region Properties

        public int Expires { get; set; }
        public string SecurityKey { get; set; }

        #endregion Properties
    }
}
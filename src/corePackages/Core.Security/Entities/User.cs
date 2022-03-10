/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using EntityFramework.Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class User : Entity
    {
        #region Properties

        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public string Username { get; set; }

        #endregion Properties
    }
}
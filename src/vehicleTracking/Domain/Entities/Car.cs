/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Core.Security.Entities;
using EntityFramework.Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Car : Entity
    {
        #region Properties

        public int NumberPlate { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

        #endregion Properties
    }
}
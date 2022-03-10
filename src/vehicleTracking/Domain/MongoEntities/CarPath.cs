/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Core.Persistence.MongoDb.Repositories;

namespace Domain.MongoEntities
{
    public class CarPath : MongoEntity
    {
        #region Properties

        public DateTime DateTime { get; set; }

        public decimal Latitute { get; set; }

        public decimal Longitude { get; set; }

        public int NumberPlate { get; set; }

        #endregion Properties
    }
}
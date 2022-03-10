/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace Core.Persistence.MongoDb
{
    public class MongoDbDatabaseSettings
    {
        #region Properties

        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        #endregion Properties
    }
}
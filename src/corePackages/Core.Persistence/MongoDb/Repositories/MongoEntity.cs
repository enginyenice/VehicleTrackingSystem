/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Persistence.MongoDb.Repositories
{
    public class MongoEntity
    {
        #region Properties

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        #endregion Properties
    }
}
/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Core.Persistence.MongoDb.Repositories
{
    public class MongoWriteRepositoryBase<TEntity> : IMongoWriteRepository<TEntity> where TEntity : MongoEntity
    {
        #region Fields

        private readonly IMongoCollection<TEntity> _mongoCollection;

        #endregion Fields

        #region Constructors

        public MongoWriteRepositoryBase(IOptions<MongoDbDatabaseSettings> mongoDbDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                mongoDbDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDbDatabaseSettings.Value.DatabaseName);

            _mongoCollection = mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #endregion Constructors

        #region Methods

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await _mongoCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
            return entity;
        }

        #endregion Methods
    }
}
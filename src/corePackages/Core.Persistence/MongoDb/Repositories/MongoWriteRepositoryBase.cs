using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.MongoDb.Repositories
{
    public class MongoWriteRepositoryBase<TEntity> : IMongoWriteRepository<TEntity> where TEntity : MongoEntity
    {
        private readonly IMongoCollection<TEntity> _mongoCollection;

        public MongoWriteRepositoryBase(IOptions<MongoDbDatabaseSettings> mongoDbDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                mongoDbDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDbDatabaseSettings.Value.DatabaseName);

            _mongoCollection = mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

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
    }
}
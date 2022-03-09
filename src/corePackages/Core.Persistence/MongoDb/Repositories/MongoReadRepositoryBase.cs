using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.MongoDb.Repositories
{
    public class MongoReadRepositoryBase<TEntity> : IMongoReadRepository<TEntity> where TEntity : MongoEntity
    {
        private readonly IMongoCollection<TEntity> _mongoCollection;

        public MongoReadRepositoryBase(IOptions<MongoDbDatabaseSettings> mongoDbDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                mongoDbDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDbDatabaseSettings.Value.DatabaseName);

            _mongoCollection = mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<TEntity> GetById(string Id)
        {
            return await _mongoCollection.Find(p => p.Id == Id).FirstOrDefaultAsync();
        }
    }
}
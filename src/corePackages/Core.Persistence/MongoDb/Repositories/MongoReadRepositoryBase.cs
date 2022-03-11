/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Core.Persistence.MongoDb.Repositories
{
    public class MongoReadRepositoryBase<TEntity> : IMongoReadRepository<TEntity> where TEntity : MongoEntity
    {
        #region Fields

        private readonly IMongoCollection<TEntity> _mongoCollection;

        #endregion Fields

        #region Constructors

        public MongoReadRepositoryBase(IOptions<MongoDbDatabaseSettings> mongoDbDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                mongoDbDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDbDatabaseSettings.Value.DatabaseName);

            _mongoCollection = mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #endregion Constructors

        #region Methods

        public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _mongoCollection.Find(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<TEntity> GetById(string Id)
        {
            return await _mongoCollection.Find(p => p.Id == Id).FirstOrDefaultAsync();
        }

        #endregion Methods
    }
}
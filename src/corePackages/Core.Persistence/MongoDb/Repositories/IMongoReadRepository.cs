/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace Core.Persistence.MongoDb.Repositories
{
    public interface IMongoReadRepository<TEntity> : IMongoRepository<TEntity> where TEntity : MongoEntity
    {
        #region Methods

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetById(string Id);

        #endregion Methods
    }
}
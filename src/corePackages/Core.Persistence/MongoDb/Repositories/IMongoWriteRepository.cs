/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace Core.Persistence.MongoDb.Repositories
{
    public interface IMongoWriteRepository<TEntity> : IMongoRepository<TEntity> where TEntity : MongoEntity
    {
        #region Methods

        Task<TEntity> CreateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        #endregion Methods
    }
}
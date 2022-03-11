/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using System.Linq.Expressions;

namespace Core.Persistence.MongoDb.Repositories
{
    public interface IMongoReadRepository<TEntity> : IMongoRepository<TEntity> where TEntity : MongoEntity
    {
        #region Methods

        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetById(string Id);

        #endregion Methods
    }
}
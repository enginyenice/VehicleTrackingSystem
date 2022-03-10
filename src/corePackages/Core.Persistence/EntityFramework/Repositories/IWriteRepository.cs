/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace EntityFramework.Core.Persistence.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region Methods

        Task<TEntity> AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        #endregion Methods
    }
}
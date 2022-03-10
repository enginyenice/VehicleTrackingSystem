/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using System.Linq.Expressions;

namespace EntityFramework.Core.Persistence.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region Methods

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true);

        Task<TEntity> GetByIdAsync(int Id, bool tracking = true);

        Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate, bool tracking = true);

        IQueryable<TEntity> Query(bool tracking = true);

        #endregion Methods
    }
}
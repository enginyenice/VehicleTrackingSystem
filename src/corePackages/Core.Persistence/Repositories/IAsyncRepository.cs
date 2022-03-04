using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        //Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> predicate = null,
        //                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                     Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        //                     int index = 0,
        //                     int size = 10,
        //                     bool enableTracking = true,
        //                     CancellationToken cancellationToken = default);

        IQueryable<TEntity> Query();

        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Core.Persistence.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true);

        Task<TEntity> GetByIdAsync(int Id, bool tracking = true);

        IQueryable<TEntity> Query(bool tracking = true);

        Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate, bool tracking = true);
    }
}
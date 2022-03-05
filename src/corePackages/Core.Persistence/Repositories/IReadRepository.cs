using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Query();

        Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate);
    }
}
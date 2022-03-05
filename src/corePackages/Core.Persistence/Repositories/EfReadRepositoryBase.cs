using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class EfReadRepositoryBase<TEntity, TContext> : IReadRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {
        public TContext Context { get; set; }

        public EfReadRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate) => await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public IQueryable<TEntity> Query() => Context.Set<TEntity>();

        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate) => await Context.Set<TEntity>().AnyAsync(predicate);
    }
}
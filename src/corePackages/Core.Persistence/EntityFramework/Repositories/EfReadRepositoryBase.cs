using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Core.Persistence.Repositories
{
    public class EfReadRepositoryBase<TEntity, TContext> : IReadRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {
        public TContext Context { get; set; }
        public DbSet<TEntity> Table { get; set; }

        public EfReadRepositoryBase(TContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> Query(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.AnyAsync(predicate);
        }

        public async Task<TEntity> GetByIdAsync(int Id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(p => p.Id == Id);
        }
    }
}
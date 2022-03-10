/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntityFramework.Core.Persistence.Repositories
{
    public class EfReadRepositoryBase<TEntity, TContext> : IReadRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {
        #region Constructors

        public EfReadRepositoryBase(TContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        #endregion Constructors

        #region Properties

        public TContext Context { get; set; }
        public DbSet<TEntity> Table { get; set; }

        #endregion Properties

        #region Methods

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(predicate);
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

        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.AnyAsync(predicate);
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

        #endregion Methods
    }
}
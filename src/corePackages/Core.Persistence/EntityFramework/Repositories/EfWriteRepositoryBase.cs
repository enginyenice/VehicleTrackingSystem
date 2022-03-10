/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Core.Persistence.Repositories
{
    public class EfWriteRepositoryBase<TEntity, TContext> : IWriteRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {
        #region Constructors

        public EfWriteRepositoryBase(TContext context)
        {
            Context = context;
        }

        #endregion Constructors

        #region Properties

        public TContext Context { get; set; }

        #endregion Properties

        #region Methods

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            Context.RemoveRange(entities);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.UpdateRange(entities);
        }

        #endregion Methods
    }
}
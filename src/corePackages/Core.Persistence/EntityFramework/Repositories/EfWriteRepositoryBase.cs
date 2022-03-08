using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Core.Persistence.Repositories
{
    public class EfWriteRepositoryBase<TEntity, TContext> : IWriteRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {
        public TContext Context { get; set; }

        public EfWriteRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.AddRangeAsync(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.UpdateRange(entities);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            Context.RemoveRange(entities);
        }
    }
}
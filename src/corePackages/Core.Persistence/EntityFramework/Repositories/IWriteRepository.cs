using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Core.Persistence.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void UpdateRange(IEnumerable<TEntity> entities);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
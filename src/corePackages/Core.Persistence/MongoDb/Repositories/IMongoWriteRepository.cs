using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.MongoDb.Repositories
{
    public interface IMongoWriteRepository<TEntity> : IMongoRepository<TEntity> where TEntity : MongoEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
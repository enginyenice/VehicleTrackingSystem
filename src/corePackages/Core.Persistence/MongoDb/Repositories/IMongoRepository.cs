using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.MongoDb.Repositories
{
    public interface IMongoRepository<TEntity> where TEntity : MongoEntity
    {
    }
}
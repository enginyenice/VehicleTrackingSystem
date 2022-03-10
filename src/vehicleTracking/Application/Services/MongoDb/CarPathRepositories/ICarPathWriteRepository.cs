using Core.Persistence.MongoDb.Repositories;
using Domain.MongoEntities;

namespace Application.Services.MongoDb.CarPathRepositories
{
    public interface ICarPathWriteRepository : IMongoWriteRepository<CarPath>
    {
    }
}
using Domain.Entities;
using EntityFramework.Core.Persistence.Repositories;

namespace Application.Services.EntityFramework.Repositories.CarRepositories
{
    public interface ICarWriteRepository : IWriteRepository<Car>
    {
    }
}
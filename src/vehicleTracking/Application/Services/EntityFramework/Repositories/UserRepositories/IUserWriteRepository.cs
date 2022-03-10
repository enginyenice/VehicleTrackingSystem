using Core.Security.Entities;
using EntityFramework.Core.Persistence.Repositories;

namespace Application.Services.EntityFramework.Repositories.UserRepositories
{
    public interface IUserWriteRepository : IWriteRepository<User>
    {
    }
}
using Domain.Entities;
using EntityFramework.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityFramework.Repositories.CarRepositories
{
    public interface ICarReadRepository : IReadRepository<Car>
    {
    }
}
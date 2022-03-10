using Application.Services.EntityFramework.Repositories.CarRepositories;
using Domain.Entities;
using EntityFramework.Core.Persistence.Repositories;
using Persistence.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework.Repositories.CarRepositories
{
    public class CarWriteRepository : EfWriteRepositoryBase<Car, BaseSqlContext>, ICarWriteRepository
    {
        public CarWriteRepository(BaseSqlContext context) : base(context)
        {
        }
    }
}
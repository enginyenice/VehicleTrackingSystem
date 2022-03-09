using Core.Persistence.MongoDb.Repositories;
using Domain.MongoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MongoDb
{
    public interface ICarDetailMongoWriteRepository : IMongoWriteRepository<CarDetail>
    {
    }
}
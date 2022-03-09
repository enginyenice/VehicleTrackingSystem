using Application.Services.MongoDb.CarPathRepositories;
using Core.Persistence.MongoDb;
using Core.Persistence.MongoDb.Repositories;
using Domain.MongoEntities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.MongoDb.Repositories.CarPathRepositories
{
    public class CarPathWriteRepository : MongoWriteRepositoryBase<CarPath>, ICarPathWriteRepository
    {
        public CarPathWriteRepository(IOptions<MongoDbDatabaseSettings> mongoDbDatabaseSettings) : base(mongoDbDatabaseSettings)
        {
        }
    }
}
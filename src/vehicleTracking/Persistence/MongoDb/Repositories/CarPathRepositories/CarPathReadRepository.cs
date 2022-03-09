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
    public class CarPathReadRepository : MongoReadRepositoryBase<CarPath>, ICarPathReadRepository
    {
        public CarPathReadRepository(IOptions<MongoDbDatabaseSettings> mongoDbDatabaseSettings) : base(mongoDbDatabaseSettings)
        {
        }
    }
}
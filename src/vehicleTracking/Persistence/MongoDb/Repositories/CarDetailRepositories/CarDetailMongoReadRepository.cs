using Application.Services.MongoDb;
using Core.Persistence.MongoDb;
using Core.Persistence.MongoDb.Repositories;
using Domain.MongoEntities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.MongoDb.Repositories.CarDetailRepositories
{
    public class CarDetailMongoReadRepository : MongoReadRepositoryBase<CarDetail>, ICarDetailMongoReadRepository
    {
        public CarDetailMongoReadRepository(IOptions<MongoDbDatabaseSettings> mongoDbDatabaseSettings) : base(mongoDbDatabaseSettings)
        {
        }
    }
}
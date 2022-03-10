/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Services.MongoDb.CarPathRepositories;
using Core.Persistence.MongoDb;
using Core.Persistence.MongoDb.Repositories;
using Domain.MongoEntities;
using Microsoft.Extensions.Options;

namespace Persistence.MongoDb.Repositories.CarPathRepositories
{
    public class CarPathReadRepository : MongoReadRepositoryBase<CarPath>, ICarPathReadRepository
    {
        #region Constructors

        public CarPathReadRepository(IOptions<MongoDbDatabaseSettings> mongoDbDatabaseSettings) : base(mongoDbDatabaseSettings)
        {
        }

        #endregion Constructors
    }
}
/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Services.EntityFramework.Repositories.CarRepositories;
using Domain.Entities;
using EntityFramework.Core.Persistence.Repositories;
using Persistence.EntityFramework.Context;

namespace Persistence.EntityFramework.Repositories.CarRepositories
{
    public class CarWriteRepository : EfWriteRepositoryBase<Car, BaseSqlContext>, ICarWriteRepository
    {
        #region Constructors

        public CarWriteRepository(BaseSqlContext context) : base(context)
        {
        }

        #endregion Constructors
    }
}
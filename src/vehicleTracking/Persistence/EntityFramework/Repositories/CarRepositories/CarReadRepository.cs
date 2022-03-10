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
    public class CarReadRepository : EfReadRepositoryBase<Car, BaseSqlContext>, ICarReadRepository
    {
        #region Constructors

        public CarReadRepository(BaseSqlContext context) : base(context)
        {
        }

        #endregion Constructors
    }
}
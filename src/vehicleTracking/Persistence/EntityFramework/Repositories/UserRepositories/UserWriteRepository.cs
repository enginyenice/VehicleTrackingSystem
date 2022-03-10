/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Services.EntityFramework.Repositories.UserRepositories;
using Core.Security.Entities;
using EntityFramework.Core.Persistence.Repositories;
using Persistence.EntityFramework.Context;

namespace Persistence.EntityFramework.Repositories.UserRepositories
{
    public class UserWriteRepository : EfWriteRepositoryBase<User, BaseSqlContext>, IUserWriteRepository
    {
        #region Constructors

        public UserWriteRepository(BaseSqlContext context) : base(context)
        {
        }

        #endregion Constructors
    }
}
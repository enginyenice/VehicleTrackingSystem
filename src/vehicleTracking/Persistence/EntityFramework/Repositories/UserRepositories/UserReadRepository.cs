using Application.Services.EntityFramework.Repositories.UserRepositories;
using EntityFramework.Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework.Repositories.UserRepositories
{
    public class UserReadRepository : EfReadRepositoryBase<User, BaseSqlContext>, IUserReadRepository
    {
        public UserReadRepository(BaseSqlContext context) : base(context)
        {
        }
    }
}
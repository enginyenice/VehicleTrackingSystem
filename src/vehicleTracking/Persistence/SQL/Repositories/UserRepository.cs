using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.SQL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SQL.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseSqlContext>, IUserRepository
    {
        public UserRepository(BaseSqlContext context) : base(context)
        {
        }
    }
}
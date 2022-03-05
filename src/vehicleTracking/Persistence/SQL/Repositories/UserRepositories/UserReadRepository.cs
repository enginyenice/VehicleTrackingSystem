﻿using Application.Services.Repositories.UserRepositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.SQL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SQL.Repositories.UserRepositories
{
    public class UserReadRepository : EfReadRepositoryBase<User, BaseSqlContext>, IUserReadRepository
    {
        public UserReadRepository(BaseSqlContext context) : base(context)
        {
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.SQL.Context;
using Application.Services.Repositories;
using Persistence.SQL.Repositories;

namespace Persistence
{
    public static class PersistenceServiceConfiguration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseSqlContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
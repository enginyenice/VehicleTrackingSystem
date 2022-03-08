using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.EntityFramework.Context;
using Application.Services.Repositories;
using Persistence.EntityFramework.Repositories;
using Application.Services.Repositories.UserRepositories;
using Persistence.EntityFramework.Repositories.UserRepositories;

namespace Persistence
{
    public static class PersistenceServiceConfiguration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseSqlContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            // Read
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            // Write
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            return services;
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.EntityFramework.Context;
using Application.Services.EntityFramework.Repositories;
using Persistence.EntityFramework.Repositories;
using Application.Services.EntityFramework.Repositories.UserRepositories;
using Persistence.EntityFramework.Repositories.UserRepositories;
using Core.Persistence.MongoDb;
using Persistence.MongoDb.Repositories.CarPathRepositories;
using Application.Services.MongoDb.CarPathRepositories;
using Application.Services.EntityFramework.Repositories.CarRepositories;
using Persistence.EntityFramework.Repositories.CarRepositories;

namespace Persistence
{
    public static class PersistenceServiceConfiguration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region EntityFramework Operations

            services.AddDbContext<BaseSqlContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            // Read
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<ICarReadRepository, CarReadRepository>();
            // Write
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<ICarWriteRepository, CarWriteRepository>();

            #endregion EntityFramework Operations

            #region MongoDb Operations

            services.Configure<MongoDbDatabaseSettings>(configuration.GetSection("MongoDbDatabaseSettings"));
            // Read
            services.AddScoped<ICarPathReadRepository, CarPathReadRepository>();
            // Write
            services.AddScoped<ICarPathWriteRepository, CarPathWriteRepository>();

            #endregion MongoDb Operations

            return services;
        }
    }
}
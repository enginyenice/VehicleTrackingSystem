/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Services.EntityFramework.Repositories.CarRepositories;
using Application.Services.EntityFramework.Repositories.UserRepositories;
using Application.Services.MongoDb.CarPathRepositories;
using Core.Persistence.MongoDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.EntityFramework.Context;
using Persistence.EntityFramework.Repositories.CarRepositories;
using Persistence.EntityFramework.Repositories.UserRepositories;
using Persistence.MongoDb.Repositories.CarPathRepositories;

namespace Persistence
{
    public static class PersistenceServiceConfiguration
    {
        #region Methods

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

        #endregion Methods
    }
}
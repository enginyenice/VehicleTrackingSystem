/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Features.Authentications.Rules;
using Application.Features.Cars.Rules;
using Core.Security.Jwt;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        #region Methods

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ITokenHelper, JwtHelper>();

            services.AddScoped<AuthenticationBusinessRules>();
            services.AddScoped<CarBusinessRules>();

            return services;
        }

        #endregion Methods
    }
}
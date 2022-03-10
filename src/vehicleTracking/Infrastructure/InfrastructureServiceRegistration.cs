/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Core.MessageBroker.RabbitMQ;
using Infrastructure.BackgroundServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        #region Methods

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(sp => new ConnectionFactory() { Uri = new Uri(configuration.GetConnectionString("RabbitMQ")), DispatchConsumersAsync = true });

            services.AddSingleton<IRabbitMQClientService, RabbitMQClientService>();
            services.AddSingleton(typeof(IRabbitMQPublisher<>), typeof(RabbitMQPublisher<>));
            services.AddHostedService<CreateCarPathBackgroundService>();

            return services;
        }

        #endregion Methods
    }
}
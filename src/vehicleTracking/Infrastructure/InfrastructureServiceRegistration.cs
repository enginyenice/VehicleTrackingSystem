using Core.MessageBroker.RabbitMQ;
using Infrastructure.BackgroundServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(sp => new ConnectionFactory() { Uri = new Uri(configuration.GetConnectionString("RabbitMQ")), DispatchConsumersAsync = true });

            services.AddSingleton<IRabbitMQClientService, RabbitMQClientService>();
            services.AddSingleton(typeof(IRabbitMQPublisher<>), typeof(RabbitMQPublisher<>));
            services.AddHostedService<CreateCarPathBackgroundService>();

            return services;
        }
    }
}
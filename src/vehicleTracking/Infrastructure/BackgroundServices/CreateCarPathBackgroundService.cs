﻿using Application.Services.MongoDb.CarPathRepositories;
using Core.MessageBroker.RabbitMQ;
using Domain.MongoEntities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.BackgroundServices
{
    public class CreateCarPathBackgroundService : BackgroundService
    {
        private readonly IRabbitMQClientService _rabbitMQClientService;
        private IModel _channel;

        private ICarPathWriteRepository _carPathWriteRepository;
        private string ExchangeName;

        private string QueueName;
        private string RoutingKey;

        public CreateCarPathBackgroundService(IRabbitMQClientService rabbitMQClientService, IServiceProvider serviceProvider)
        {
            _rabbitMQClientService = rabbitMQClientService;
            ExchangeName = $"{typeof(CarPath).Name}.Exchange".ToLower();
            QueueName = $"{typeof(CarPath).Name}.Queue".ToLower();
            RoutingKey = $"{typeof(CarPath).Name}.RoutingKey".ToLower();
            _carPathWriteRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ICarPathWriteRepository>();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMQClientService.Connect();
            _channel.BasicQos(0, 1, false);
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume(QueueName, false, consumer);
            consumer.Received += Consumer_Received;
            return Task.CompletedTask;
        }

        private Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            //Gelen mesajı aldık
            var carPath = JsonSerializer.Deserialize<CarPath>(Encoding.UTF8.GetString(@event.Body.ToArray()));
            _carPathWriteRepository.CreateAsync(carPath);
            _channel.BasicAck(@event.DeliveryTag, false);
            return Task.CompletedTask;
        }
    }
}
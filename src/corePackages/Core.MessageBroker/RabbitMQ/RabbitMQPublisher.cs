using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.MessageBroker.RabbitMQ
{
    public class RabbitMQPublisher<TEntity> : IRabbitMQPublisher<TEntity> where TEntity : class
    {
        private readonly IRabbitMQClientService _rabbitMQClientService;
        private string ExchangeName;
        private string QueueName;
        private string RoutingKey;

        public RabbitMQPublisher(IRabbitMQClientService rabbitMQClientService)
        {
            _rabbitMQClientService = rabbitMQClientService;
            ExchangeName = $"{typeof(TEntity).Name}.Exchange".ToLower();
            QueueName = $"{typeof(TEntity).Name}.Queue".ToLower();
            RoutingKey = $"{typeof(TEntity).Name}.RoutingKey".ToLower();
        }

        public void Publish(TEntity entity, string exchangeType = ExchangeType.Fanout)
        {
            var channel = _rabbitMQClientService.Connect();
            channel.ExchangeDeclare(ExchangeName, exchangeType);
            channel.QueueDeclare(QueueName, true, false, false, null);
            channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: RoutingKey);

            var bodyString = JsonSerializer.Serialize(entity);
            var bodyByte = Encoding.UTF8.GetBytes(bodyString);
            channel.BasicPublish(

                exchange: $"{typeof(TEntity).Name}.Exchange".ToLower(),
                     routingKey: "",
                     basicProperties: null,
                     body: bodyByte);
        }
    }
}
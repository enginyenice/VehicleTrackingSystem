/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Core.MessageBroker.RabbitMQ
{
    public class RabbitMQPublisher<TEntity> : IRabbitMQPublisher<TEntity> where TEntity : class
    {
        #region Fields

        private readonly IRabbitMQClientService _rabbitMQClientService;
        private string ExchangeName;
        private string QueueName;
        private string RoutingKey;

        #endregion Fields

        #region Constructors

        public RabbitMQPublisher(IRabbitMQClientService rabbitMQClientService)
        {
            _rabbitMQClientService = rabbitMQClientService;
            ExchangeName = $"{typeof(TEntity).Name}.Exchange".ToLower();
            QueueName = $"{typeof(TEntity).Name}.Queue".ToLower();
            RoutingKey = $"{typeof(TEntity).Name}.RoutingKey".ToLower();
        }

        #endregion Constructors

        #region Methods

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

        #endregion Methods
    }
}
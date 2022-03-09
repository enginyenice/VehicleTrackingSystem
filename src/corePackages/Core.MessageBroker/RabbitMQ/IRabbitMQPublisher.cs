using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MessageBroker.RabbitMQ
{
    public interface IRabbitMQPublisher<TEntity> where TEntity : class
    {
        public void Publish(TEntity entity, string exchangeType = ExchangeType.Fanout);
    }
}
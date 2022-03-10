/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using RabbitMQ.Client;

namespace Core.MessageBroker.RabbitMQ
{
    public interface IRabbitMQPublisher<TEntity> where TEntity : class
    {
        #region Methods

        public void Publish(TEntity entity, string exchangeType = ExchangeType.Fanout);

        #endregion Methods
    }
}
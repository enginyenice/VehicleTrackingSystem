/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using RabbitMQ.Client;

namespace Core.MessageBroker.RabbitMQ
{
    public interface IRabbitMQClientService : IDisposable
    {
        #region Methods

        public IModel Connect();

        #endregion Methods
    }
}
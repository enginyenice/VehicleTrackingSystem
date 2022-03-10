/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using RabbitMQ.Client;

namespace Core.MessageBroker.RabbitMQ
{
    public class RabbitMQClientService : IRabbitMQClientService
    {
        #region Fields

        private readonly ConnectionFactory _connectionFactory;
        private IModel _channel;
        private IConnection _connection;

        #endregion Fields

        #region Constructors

        public RabbitMQClientService(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #endregion Constructors

        #region Methods

        public IModel Connect()
        {
            _connection = _connectionFactory.CreateConnection();
            if (_channel is { IsOpen: true }) return _channel;
            _channel = _connection.CreateModel();
            return _channel;
        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
        }

        #endregion Methods
    }
}
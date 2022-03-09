using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MessageBroker.RabbitMQ
{
    public interface IRabbitMQClientService : IDisposable
    {
        public IModel Connect();
    }
}
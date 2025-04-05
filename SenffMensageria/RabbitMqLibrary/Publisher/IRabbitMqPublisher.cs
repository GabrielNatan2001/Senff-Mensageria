using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMqLibrary.Enum;

namespace RabbitMqLibrary.Publisher
{
    public interface IRabbitMqPublisher
    {
        Task PublishAsync<T>(T message, string routingKey, string exchangeName = "");
        void CreateExchange(string exchangeName, EExchangeType type, bool durable = true, bool autoDelete = false);
        void CreateQueue(string queueName, bool durable = true, bool exclusive = false, bool autoDelete = false);
        void BindQueueToExchange(string exchangeName, string queueName, string routingKey);
    }
}

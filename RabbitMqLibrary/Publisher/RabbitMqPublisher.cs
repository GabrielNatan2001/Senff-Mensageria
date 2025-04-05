using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMqLibrary.Enum;
using RabbitMqLibrary.Extensions;

namespace RabbitMqLibrary.Publisher
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        private readonly IModel _channel;
        public RabbitMqPublisher(string hostname, string user, string password, int port = 5672)
        {
            _channel = CreateChannel(hostname, user, password, port);
        }
        private IModel CreateChannel(string hostname, string user, string password, int port)
        {
            var factory = new ConnectionFactory()
            {
                HostName = hostname,
                UserName = user,
                Password = password,
                Port = port
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            return channel;
        }
        public void CreateExchange(string exchangeName, EExchangeType type, bool durable = true, bool autoDelete = false)
        {
            _channel.ExchangeDeclare(exchangeName, type.ToRabbitMQType(), durable: true, autoDelete: false, null);
        }
        public void CreateQueue(string queueName, bool durable = true, bool exclusive = false, bool autoDelete = false)
        {
            _channel.QueueDeclare(
                queueName,
                durable,
                exclusive,
                autoDelete
                );
        }
        public void BindQueueToExchange(string exchangeName, string queueName, string routingKey)
        {
            _channel.QueueBind(queueName, exchangeName, routingKey);
        }
        public async Task PublishAsync<T>(T message, string routingKey, string exchangeName = "")
        {
            try
            {
                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);

                await Task.Run(() =>
                {
                    _channel.BasicPublish(
                        exchange: exchangeName,
                        routingKey: routingKey,
                        basicProperties: null,
                        body: body);
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to publish message", ex);
            }
        }
    }
}

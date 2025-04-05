using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqLibrary.Consumer
{
    public class RabbitMqConsumer : IRabbitMqConsumer
    {
        private readonly IModel _channel;
        public RabbitMqConsumer(string hostname, string user, string password, int port = 5672)
        {
            _channel = CreateChannel(hostname, user, password, port);
        }

        private IModel CreateChannel(string hostname, string user, string password, int port = 5672)
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
        public void QueueListener(string queueName, Action<string> onMessageReceived)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, eventArgs) =>
            {
                try
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    _channel.BasicAck(eventArgs.DeliveryTag, false);
                    onMessageReceived?.Invoke(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _channel.BasicNack(eventArgs.DeliveryTag, false, false);
                }
            };

            _channel.BasicConsume(queueName, false, consumer);

            Console.ReadKey();
        }
    }
}

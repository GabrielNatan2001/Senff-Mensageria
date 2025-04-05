// See https://aka.ms/new-console-template for more information

using RabbitMqLibrary.Consumer;
using RabbitMqLibrary.Enum;
using RabbitMqLibrary.Publisher;

//var exchangeName = "testeLib";
//var queueName = "fila-lib";

//var publish = new RabbitMqPublisher("localhost", "guest", "guest");

//publish.CreateExchange(exchangeName, EExchangeType.DIRECT);
//publish.CreateQueue(queueName);
//publish.BindQueueToExchange(exchangeName, queueName, "123");
//publish.BindQueueToExchange(exchangeName, queueName, "321");


//for (var i = 0; i < 10; i++)
//{
//    await publish.PublishAsync("teste " + i + 1.ToString() + " data hora: " + DateTime.Now.ToString(), "123", exchangeName);
//}
//for (var i = 0; i < 10; i++)
//{
//    await publish.PublishAsync("teste " + i + 1.ToString() + " data hora: " + DateTime.Now.ToString(), "321", exchangeName);
//}

var queueName = "fila-lib";
var consumer = new RabbitMqConsumer("localhost", "guest", "guest");

consumer.QueueListener(queueName, message =>
{
    Console.WriteLine($"Mensagem recebida: {message}");
});
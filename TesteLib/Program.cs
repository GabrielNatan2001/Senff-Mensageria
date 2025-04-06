using Microsoft.Extensions.DependencyInjection;
using RabbitMqLibrary.Consumer;
using RabbitMqLibrary.Extensions;


var serviceCollection = new ServiceCollection();
serviceCollection.AddRabbitMQ("localhost", "guest", "guest");

var serviceProvider = serviceCollection.BuildServiceProvider();
var consumer = serviceProvider.GetRequiredService<IRabbitMqConsumer>();

consumer.QueueListener("Matricula", async message =>
{
    Console.WriteLine($"Mensagem recebida: {message}");
});
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMqLibrary.Consumer;
using RabbitMqLibrary.Extensions;
using SenffMensageria.Domain.Repositories;
using SenffMensageria.Infrastructure;
using Shared.DTO;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


var serviceCollection = new ServiceCollection();
serviceCollection.AddRabbitMQ("localhost", "guest", "guest");
serviceCollection.AddInfrastructure(configuration);
var serviceProvider = serviceCollection.BuildServiceProvider();

var consumer = serviceProvider.GetRequiredService<IRabbitMqConsumer>();
var repository = serviceProvider.GetRequiredService<IMatriculaRepository>();

consumer.QueueListener("Matricula", async message =>
{
    try
    {
        Console.WriteLine($"Mensagem recebida: {message}");
        var matricula = JsonSerializer.Deserialize<MatriculaDto>(message);

        if (matricula != null)
        {
            var entity = await repository.GetById(matricula.Id);
            entity.EfetivarMatricula();
            repository.Commit();

             Console.WriteLine($"Matricula efetivada com sucesso!");
        }
    }
    catch(Exception e)
    {
        Console.WriteLine($"Erro ao processar mensagem: {e.Message}");
    }
});
# Sobre o projeto
Solução de mensageria com RabbitMQ

# Funcionalidade do Projeto 
A biblioteca RabbitMqLibrarySenff(disponível em https://www.nuget.org/packages/RabbitMqLibrarySenff/) é responsável por abstrari a integração com o RabbitMq, assim sendo possivel criar queue, exchange, envio de mensagem e consumo. A projeto foi desenvolvido em .net 8 para realizar o registro de aluno e sua matricula, a cada nova matricula o projeto dispara uma mensagem para efetivar a matricula do aluno(alterar status de pré-matricula para maticulado).

# Rodar com Docker
Para rodar o projeto com o docker é necessário entrar na pasta raiz do projeto onde contém o dockerfile e o docker-compose, digitar o comando "docker-compose build" e em seguinda o comando "docker-compose up" feito isso, a API estará na porta 5000(http://localhost:5000/swagger/index.html) e o rabbit mq na porta 5672.


# RabbitMqLibrary

## Recursos
- Publicação assíncrona de mensagens com suporte a tipagem genérica.
- Criação de exchanges com tipos personalizáveis.
- Criação de filas com opções de durabilidade, exclusividade e auto exclusão.
- Associação (binding) entre filas e exchanges com routing keys.
- Consumo de mensagens de uma fila

## Instalação
Adicione a referência do projeto RabbitMqLibrarySenff

## Exemplo de Uso:

### Publisher
```csharp
var publisher = new IRabbitMqPublisher();

// Criando um exchange e uma fila
publisher.CreateExchange("meu-exchange", EExchangeType.Direct);
publisher.CreateQueue("minha-fila");

// Vinculando fila ao exchange
publisher.BindQueueToExchange("meu-exchange", "minha-fila", "rota.teste");

// Publicando uma mensagem
await publisher.PublishAsync(new { Nome = "João", Idade = 30 }, "rota.teste", "meu-exchange");
```
### Consumer
```csharp
var consumer = new IRabbitMqConsumer();
consumer.QueueListener("Matricula", async message =>
{
   Console.WriteLine($"Mensagem recebida: {message}");
});
```

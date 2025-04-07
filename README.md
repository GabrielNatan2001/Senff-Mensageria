# Sobre o projeto
Solução de mensageria com RabbitMQ

# Funcionalidade do Projeto 
A biblioteca RabbitMqLibrarySenff(disponível em https://www.nuget.org/packages/RabbitMqLibrarySenff/) é responsável por abstrair a integração com o RabbitMq, assim sendo possivel criar queue, exchange, envio de mensagem e consumo. A projeto foi desenvolvido em .net 8 para realizar o registro de aluno e sua matricula, a cada nova matricula o projeto dispara uma mensagem para efetivar a matricula do aluno(alterar status de pré-matricula para maticulado).

# Rodar com Docker
Para rodar o projeto com o docker é necessário entrar na pasta raiz do projeto onde contém o dockerfile e o docker-compose, digitar o comando "docker-compose build" e em seguinda o comando "docker-compose up" feito isso, a API estará na porta 5000(http://localhost:5000/swagger/index.html) e o rabbit mq na porta 5672.


# RabbitMqLibrary

## Recursos
- Publicação assíncrona de mensagens com suporte a tipagem genérica.
- Criação de exchanges com tipos personalizáveis.
- Criação de filas com opções de durabilidade, exclusividade e auto exclusão.
- Associação (binding) entre filas e exchanges com routing keys.
- Consumo de mensagens de uma fila

## Métodos e parâmetros
### IRabbitMqPublisher
#### PublishAsync<T>(T message, string routingKey, string exchangeName = "")
| Nome do Parâmetro | Tipo         | Obrigatório | Descrição                                   |
|-------------------|--------------|------------|----------------------------------------------|
| `message`         | `T/Genérico` | ✅        | Objeto que será serializado e publicado.      |
| `routingKey`      | `string`     | ✅        | Chave usada para o roteamento da mensagem.    |
| `exchangeName`    | `string`     | ❌        | Exchange alvo. Padrão: `""` (exchange padrão).|

#### CreateExchange(string exchangeName, EExchangeType type, bool durable = true, bool autoDelete = false);
| Nome do Parâmetro | Tipo            | Obrigatório | Descrição                                                                 |
|-------------------|-----------------|-------------|---------------------------------------------------------------------------|
| `exchangeName`    | `string`        | ✅           | Nome do exchange a ser criado.                                            |
| `type`            | `EExchangeType` | ✅           | Tipo do exchange (`Direct`, `Fanout`, `Topic`, `Headers`).                |
| `durable`         | `bool`          | ❌           | Define se o exchange persiste após reinicialização (padrão: `true`).      |
| `autoDelete`      | `bool`          | ❌           | Se o exchange será removido automaticamente quando não estiver em uso.    |

#### CreateQueue(string queueName, bool durable = true, bool exclusive = false, bool autoDelete = false)
| Nome do Parâmetro | Tipo     | Obrigatório | Descrição                                                                 |
|-------------------|----------|-------------|---------------------------------------------------------------------------|
| `queueName`       | `string` | ✅           | Nome da fila a ser criada.                                                |
| `durable`         | `bool`   | ❌           | Define se a fila persiste após reinicializações (padrão: `true`).         |
| `exclusive`       | `bool`   | ❌           | Se `true`, a fila é exclusiva para a conexão que a declarou (padrão: `false`). |
| `autoDelete`      | `bool`   | ❌           | Se a fila será removida automaticamente quando não estiver em uso.        |

#### BindQueueToExchange(string exchangeName, string queueName, string routingKey);
| Nome do Parâmetro | Tipo     | Obrigatório | Descrição                                                                 |
|-------------------|----------|-------------|---------------------------------------------------------------------------|
| `exchangeName`    | `string` | ✅           | Nome do exchange ao qual a fila será vinculada.                           |
| `queueName`       | `string` | ✅           | Nome da fila que será associada ao exchange.                              |
| `routingKey`      | `string` | ✅           | Chave de roteamento usada para vincular a fila ao exchange.               |

### IRabbitMqConsumer
#### QueueListener(string queue, Action<string> onMessageReceived);
| Nome do Parâmetro     | Tipo              | Obrigatório | Descrição                                                                 |
|-----------------------|-------------------|-------------|---------------------------------------------------------------------------|
| `queue`               | `string`          | ✅           | Nome da fila que será ouvida para receber mensagens.                      |
| `onMessageReceived`   | `Action<string>`  | ✅           | Função callback que será executada ao receber uma nova mensagem da fila. |

## Instalação
Adicione a referência do projeto RabbitMqLibrarySenff


### Configuração 
```csharp
//Adicionar no startup do projeto
var hostname = "localhost";
var user = "guest";
var password = "guest";
var port = 5672;

services.AddRabbitMQ(hostname, user, password, port);
```

## Exemplo de Uso:
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
consumer.QueueListener("minha-fila", async message =>
{
   Console.WriteLine($"Mensagem recebida: {message}");
});
```

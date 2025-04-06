# Sobre o projeto
Solução de mensageria com RabbitMQ

# Funcionalidade do Projeto 
A biblioteca RabbitMqLibrarySenff(disponível em https://www.nuget.org/packages/RabbitMqLibrarySenff/) é responsável por abstrari a integração com o RabbitMq, assim sendo possivel criar queue, exchange, envio de mensagem e consumo. A projeto foi desenvolvido em .net 8 para realizar o registro de aluno e sua matricula, a cada nova matricula o projeto dispara uma mensagem para efetivar a matricula do aluno(alterar status de pré-matricula para maticulado).

# Rodar com Docker
Para rodar o projeto com o docker é necessário entrar na pasta raiz do projeto onde contém o dockerfile e o docker-compose, digitar o comando "docker-compose build" e em seguinda o comando "docker-compose up" feito isso, a API estará na porta 5000(http://localhost:5000/swagger/index.html) e o rabbit mq na porta 5672.

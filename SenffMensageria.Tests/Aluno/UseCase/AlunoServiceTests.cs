using FluentAssertions;
using Moq;
using SenffMensageria.Application.UseCase.Aluno;
using SenffMensageria.Domain.Exceptions;
using SenffMensageria.Domain.Repositories;
using Shared.DTO;

namespace SenffMensageria.Tests.Aluno.UseCase
{
    public class AlunoServiceTests
    {
        private readonly Mock<IAlunoRepository> _repository;

        public AlunoServiceTests()
        {
            _repository = new Mock<IAlunoRepository>();
        }

        [Fact]
        public async Task Sucesso_Ao_Adicionar()
        {
            var service = CreateService();
            var request = new AlunoDto()
            {
                Nome = "teste",
                Email = "teste@gmail.com"
            };

            var result = await service.Adicionar(request);

            result.Should().NotBeNull();
            result.Nome.Should().Be(result.Nome);
            result.Email.Should().Be(result.Email);
        }

        [Fact]
        public async Task Erro_Nome_Vazio()
        {
            var service = CreateService();
            var request = new AlunoDto()
            {
                Email = "teste@gmail.com"
            };

            Func<Task> act = async () => await service.Adicionar(request);
            await act.Should().ThrowAsync<ErroAoValidarException>()
                 .Where(ex => ex.Message.Equals("Nome não pode ser nulo ou vazio."));
        }

        [Fact]
        public async Task Erro_Email_Vazio()
        {
            var service = CreateService();
            var request = new AlunoDto()
            {
                Nome = "teste"
            };

            Func<Task> act = async () => await service.Adicionar(request);
            await act.Should().ThrowAsync<ErroAoValidarException>()
                 .Where(ex => ex.Message.Equals("Email não pode ser nulo ou vazio."));
        }


        [Fact]
        public async Task Sucesso_Ao_Atualizar()
        {
            var service = CreateService();
            var request = new AlunoDto()
            {
                Id = 1,
                Nome = "teste",
                Email = "teste@gmail.com"
            };
            _repository.Setup(a => a.GetById(request.Id)).ReturnsAsync(new Domain.Entities.Aluno(request.Nome, request.Email));

            var result = await service.Atualizar(1, request);

            result.Should().NotBeNull();
            result.Nome.Should().Be(result.Nome);
            result.Email.Should().Be(result.Email);
        }

        [Fact]
        public async Task Erro_Ao_Atualizar_Id_Nao_Encontrado()
        {
            var service = CreateService();
            var request = new AlunoDto()
            {
                Id = 1,
                Nome = "teste",
                Email = "teste@gmail.com"
            };

            Func<Task> act = async () => await service.Atualizar(request.Id, request);
            await act.Should().ThrowAsync<ObjetoNaoEncontradoException>();
        }

        [Fact]
        public async Task Sucesso_Buscar_Todos()
        {
            var service = CreateService();

            _repository.Setup(a => a.GetAll())
                .ReturnsAsync(
                    new List<Domain.Entities.Aluno>
                    {
                        new Domain.Entities.Aluno("teste1",  "teste@gmail.com"),
                        new Domain.Entities.Aluno("teste2",  "teste@gmail.com"),
                        new Domain.Entities.Aluno("teste3",  "teste@gmail.com"),
                    }
                );

            var result = await service.GetAll();
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
        }

        [Fact]
        public async Task Sucesso_Buscar_Por_Id()
        {
            var service = CreateService(); 
            var request = new AlunoDto()
            {
                Id = 1,
                Nome = "teste",
                Email = "teste@gmail.com"
            };

            _repository.Setup(a => a.GetById(request.Id)).ReturnsAsync(new Domain.Entities.Aluno(request.Nome, request.Email));

            var result = await service.GetById(1);

            result.Should().NotBeNull();
            result.Nome.Should().Be(result.Nome);
            result.Email.Should().Be(result.Email);
        }

        private AlunoService CreateService()
        {
            return new AlunoService(_repository.Object);
        }
    }
}

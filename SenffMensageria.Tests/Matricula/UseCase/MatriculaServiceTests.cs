using FluentAssertions;
using Moq;
using RabbitMqLibrary.Publisher;
using SenffMensageria.Application.UseCase.Matricula;
using SenffMensageria.Domain.Exceptions;
using SenffMensageria.Domain.Repositories;
using Shared.DTO;

namespace SenffMensageria.Tests.Matricula.UseCase
{
    public class MatriculaServiceTests
    {
        private readonly Mock<IMatriculaRepository> _repository;
        private readonly Mock<IRabbitMqPublisher> _publisher;

        public MatriculaServiceTests()
        {
            _repository = new Mock<IMatriculaRepository>();
            _publisher = new Mock<IRabbitMqPublisher>();
        }

        [Fact]
        public async Task Sucesso_Ao_Adicionar()
        {
            var service = CreateService();
            var request = new MatriculaDto()
            {
                Turma = "Turma 1",
                Status = Domain.Enum.EStatusMatricula.PREMATRICULA,
                AlunoId = 1
            };

            var result = await service.Adicionar(request);

            result.Should().NotBeNull();
            result.Turma.Should().Be("Turma 1");
            result.AlunoId.Should().Be(1);
        }

        [Fact]
        public async Task Sucesso_Buscar_Por_Id()
        {
            var service = CreateService();
            var request = new MatriculaDto()
            {
                Id = 1,
                Turma = "Turma 1",
                Status = Domain.Enum.EStatusMatricula.PREMATRICULA,
                AlunoId = 1
            };

            _repository.Setup(a => a.GetById(request.Id)).ReturnsAsync(new Domain.Entities.Matricula(1, "Turma 1"));

            var result = await service.Adicionar(request);

            result.Should().NotBeNull();
            result.Turma.Should().Be("Turma 1");
            result.AlunoId.Should().Be(1);
        }

        [Fact]
        public async Task Erro_Passando_Turma_Invalida()
        {
            var service = CreateService();
            var request = new MatriculaDto()
            {
                Id = 1,
                Turma = "",
                Status = Domain.Enum.EStatusMatricula.PREMATRICULA,
                AlunoId = 1
            };

            _repository.Setup(a => a.GetById(request.Id)).ReturnsAsync(new Domain.Entities.Matricula(1, "Turma 1"));

            Func<Task> act = async () => await service.Adicionar(request);
            await act.Should().ThrowAsync<ErroAoValidarException>()
                 .Where(ex => ex.Message.Equals("Turma não pode ser nulo ou vazio."));
        }

        [Fact]
        public async Task Erro_Passando_IdAluno_Invalida()
        {
            var service = CreateService();
            var request = new MatriculaDto()
            {
                Id = 1,
                Turma = "teste",
                Status = Domain.Enum.EStatusMatricula.PREMATRICULA,
                AlunoId = 0
            };

            _repository.Setup(a => a.GetById(request.Id)).ReturnsAsync(new Domain.Entities.Matricula(1, "Turma 1"));

            Func<Task> act = async () => await service.Adicionar(request);
            await act.Should().ThrowAsync<ErroAoValidarException>()
                 .Where(ex => ex.Message.Equals("AlunoId não pode ser vazio"));
        }

        private MatriculaService CreateService()
        {
            var validator = new MatriculaValidator();
            return new MatriculaService(_repository.Object, _publisher.Object, validator);
        }
    }
}

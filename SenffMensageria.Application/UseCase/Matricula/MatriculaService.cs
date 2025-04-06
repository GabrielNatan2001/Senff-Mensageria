using RabbitMqLibrary.Enum;
using RabbitMqLibrary.Publisher;
using SenffMensageria.Domain.Repositories;
using Shared.DTO;

namespace SenffMensageria.Application.UseCase.Matricula
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repository;
        private readonly IRabbitMqPublisher _publisher;

        public MatriculaService(IMatriculaRepository repository, IRabbitMqPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;

            _publisher.CreateExchange("MatriculaEx", EExchangeType.DIRECT);
            _publisher.CreateQueue("Matricula");
            _publisher.BindQueueToExchange("MatriculaEx", "Matricula", "");
        }
        public async Task Adicionar(MatriculaDto request)
        {
            var entity = new Domain.Entities.Matricula(request.AlunoId, request.Turma, request.Status);

            await _repository.Add(entity);
            await _repository.Commit();
            request.Id = entity.Id;

            await _publisher.PublishAsync(request, "Matricula");
        }

        public async Task<MatriculaDto> GetById(int id)
        {
            var resultEntity = await _repository.GetById(id);

            if (resultEntity == null) throw new Exception("Matricula não encontrada");

            return new MatriculaDto()
            {
                Id = resultEntity.Id,
                Turma = resultEntity.Turma,
                Status = resultEntity.Status,
                AlunoId = resultEntity.AlunoId
            };
        }
    }
}

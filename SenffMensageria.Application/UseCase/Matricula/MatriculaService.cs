using FluentValidation;
using RabbitMqLibrary.Enum;
using RabbitMqLibrary.Publisher;
using SenffMensageria.Domain.Exceptions;
using SenffMensageria.Domain.Repositories;
using Shared.DTO;

namespace SenffMensageria.Application.UseCase.Matricula
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repository;
        private readonly IRabbitMqPublisher _publisher;
        private readonly IValidator<MatriculaDto> _validator;

        public MatriculaService(IMatriculaRepository repository, IRabbitMqPublisher publisher, IValidator<MatriculaDto> validator)
        {
            _repository = repository;
            _publisher = publisher;
            _validator = validator;

            _publisher.CreateExchange("MatriculaEx", EExchangeType.DIRECT);
            _publisher.CreateQueue("Matricula");
            _publisher.BindQueueToExchange("MatriculaEx", "Matricula", "");
        }
        public async Task<MatriculaDto> Adicionar(MatriculaDto request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ErroAoValidarException(string.Join("\n", validationResult.Errors));
            
            var entity = new Domain.Entities.Matricula(request.AlunoId, request.Turma, request.Status);

            await _repository.Add(entity);
            await _repository.Commit();
            request.Id = entity.Id;

            await _publisher.PublishAsync(request, "Matricula");

            return new MatriculaDto
            {
                Id = entity.Id,
                Turma = entity.Turma,
                Status = entity.Status,
                AlunoId = entity.AlunoId
            };
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

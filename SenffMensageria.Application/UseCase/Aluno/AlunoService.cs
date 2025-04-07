using System.Linq;
using FluentValidation;
using SenffMensageria.Domain.Exceptions;
using SenffMensageria.Domain.Repositories;
using Shared.DTO;

namespace SenffMensageria.Application.UseCase.Aluno
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly IValidator<AlunoDto> _validator;

        public AlunoService(IAlunoRepository repository, IValidator<AlunoDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<AlunoDto> Adicionar(AlunoDto request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ErroAoValidarException(string.Join("\n" ,validationResult.Errors));

            var entity = new Domain.Entities.Aluno(request.Nome, request.Email);

            await _repository.Add(entity);
            await _repository.Commit();

            return new AlunoDto()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Email = entity.Email
            };
        }

        public async Task<AlunoDto> Atualizar(int id, AlunoDto request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ErroAoValidarException(string.Join("\n", validationResult.Errors));

            var entity = await _repository.GetById(id);

            if (entity == null) throw new ObjetoNaoEncontradoException("Aluno não encontrado");

            entity.AtualizarNome(request.Nome);
            entity.AtualizarEmail(request.Email);

            await _repository.Commit();

            return new AlunoDto()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Email = entity.Email
            };
        }

        public async Task<List<AlunoDto>> GetAll()
        {
            var resultEntity  = await _repository.GetAll();

            if (resultEntity == null) throw new ObjetoNaoEncontradoException("Nenhum aluno encontrado no sistema");

            var resultDto = resultEntity.Select(x => new AlunoDto()
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email
            }).ToList();

            return resultDto;
        }

        public async Task<AlunoDto> GetById(int id)
        {
            var resultEntity = await _repository.GetById(id);
            if (resultEntity == null) return null;

            return new AlunoDto()
            {
                Id = resultEntity.Id,
                Nome = resultEntity.Nome,
                Email = resultEntity.Email
            };
        }

        public async Task Remover(int id)
        {
            await _repository.Remove(id);
            await _repository.Commit();
        }
    }
}

using SenffMensageria.Domain.Repositories;
using Shared.DTO;

namespace SenffMensageria.Application.UseCase.Aluno
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public async Task Adicionar(AlunoDto request)
        {
            var entity = new Domain.Entities.Aluno(request.Nome, request.Email);

            await _repository.Add(entity);
            await _repository.Commit();
        }

        public async Task Atualizar(int id, AlunoDto request)
        {
            var entity = await _repository.GetById(id);

            if (entity == null) throw new Exception("Aluno não encontrado");

            entity.AtualizarNome(request.Nome);
            entity.AtualizarEmail(request.Email);

            await _repository.Commit();
        }

        public async Task<List<AlunoDto>> GetAll()
        {
            var resultEntity  = await _repository.GetAll();

            if (resultEntity == null) throw new Exception("Nenhum aluno encontrado no sistema");

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

using Shared.DTO;

namespace SenffMensageria.Application.UseCase.Aluno
{
    public interface IAlunoService
    {
        Task Adicionar(AlunoDto request);
        Task Atualizar(int id, AlunoDto request);
        Task Remover(int id);
        Task<AlunoDto> GetById(int id);
        Task<List<AlunoDto>> GetAll();
    }
}

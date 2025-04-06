using SenffMensageria.Domain.Entities;

namespace SenffMensageria.Domain.Repositories
{
    public interface IAlunoRepository: IBaseRepository
    {
        Task Add(Aluno entity);
        Task Remove(int id);
        Task<Aluno?> GetById(int id);
        Task<List<Aluno>?> GetAll();
    }
}

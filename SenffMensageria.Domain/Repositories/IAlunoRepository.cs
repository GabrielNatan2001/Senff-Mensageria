using SenffMensageria.Domain.Entities;

namespace SenffMensageria.Domain.Repositories
{
    public interface IAlunoRepository: IBaseRepository
    {
        Task<Aluno> Add(Aluno entity);
        Task Remove(int id);
        Task<Aluno?> GetById(int id);
        Task<List<Aluno>?> GetAll();
    }
}

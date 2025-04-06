using Microsoft.EntityFrameworkCore;
using SenffMensageria.Domain.Entities;
using SenffMensageria.Domain.Exceptions;
using SenffMensageria.Domain.Repositories;

namespace SenffMensageria.Infrastructure.DataAccess.Repositories
{
    public class AlunoRepository : BaseRepository, IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task Add(Aluno entity)
        {
            await _context.Alunos.AddAsync(entity);
        }

        public async Task Remove(int id)
        {
            var entity = await GetById(id);
            if(entity == null) {
                throw new ObjetoNaoEncontradoException($"Aluno com id {id} não encontrado ao remover.");
            }
            _context.Alunos.Remove(entity);
        }

        public async Task<List<Aluno>?> GetAll()
        {
            return await _context.Alunos.AsNoTracking().ToListAsync();
        }

        public async Task<Aluno?> GetById(int id)
        {
            return await _context.Alunos.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SenffMensageria.Domain.Entities;
using SenffMensageria.Domain.Repositories;

namespace SenffMensageria.Infrastructure.DataAccess.Repositories
{
    public class MatriculaRepository : BaseRepository, IMatriculaRepository
    {
        private readonly AppDbContext _context;

        public MatriculaRepository(AppDbContext context): base(context)
        {
            _context = context;
        }
        public async Task Add(Matricula entity)
        {
            await _context.Matriculas.AddAsync(entity);
        }

        public async Task<Matricula?> GetById(int id)
        {
            return await _context.Matriculas.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

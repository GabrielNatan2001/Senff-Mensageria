using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SenffMensageria.Domain.Entities;

namespace SenffMensageria.Domain.Repositories
{
    public interface IMatriculaRepository : IBaseRepository
    {
        Task<Matricula> Add(Matricula entity);
        Task<Matricula?> GetById(int id);
    }
}

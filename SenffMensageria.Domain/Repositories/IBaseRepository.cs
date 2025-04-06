using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenffMensageria.Domain.Repositories
{
    public interface IBaseRepository
    {
        Task Commit();
    }
}

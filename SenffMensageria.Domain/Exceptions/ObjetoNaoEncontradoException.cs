using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenffMensageria.Domain.Exceptions
{
    public class ObjetoNaoEncontradoException: BaseException
    {
        public ObjetoNaoEncontradoException(string mensagem)
        : base(mensagem)
        {
        }
    }
}

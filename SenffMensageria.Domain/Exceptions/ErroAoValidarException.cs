namespace SenffMensageria.Domain.Exceptions
{
    public class ErroAoValidarException : BaseException
    {
        public ErroAoValidarException(string mensagem)
        : base(mensagem)
        {
        }
    }
}

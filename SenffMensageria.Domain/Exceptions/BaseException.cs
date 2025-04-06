namespace SenffMensageria.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException(string mensagem)
        : base(mensagem)
        {
        }
    }
}

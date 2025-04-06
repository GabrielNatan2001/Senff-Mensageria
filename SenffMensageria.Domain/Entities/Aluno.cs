using SenffMensageria.Domain.Exceptions;

namespace SenffMensageria.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public Matricula Matricula { get; private set; }

        public Aluno(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Validate();
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
            Validate();

        }
        public void AtualizarEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome)) throw new ErroAoValidarException("Nome não pode ser nulo ou vazio.");
            if (string.IsNullOrEmpty(Email)) throw new ErroAoValidarException("Email não pode ser nulo ou vazio.");
        }
    }
}

using FluentAssertions;
using SenffMensageria.Domain.Exceptions;
using Shared.DTO;

namespace SenffMensageria.Tests.Aluno.Entity
{
    public class AlunoTests
    {
        [Fact]
        public void Sucesso_Ao_Criar()
        {
            var nome = "Teste";
            var email = "teste@gmail.com";

            var entity = new Domain.Entities.Aluno(nome, email);

            entity.Should().NotBeNull();
            entity.Nome.Should().Be(nome);
            entity.Email.Should().Be(email);
        }

        [Fact]
        public void Erro_Ao_Passar_Nome_Vazio()
        {
            Action act = () => new Domain.Entities.Aluno("", "teste@gmail.com");

            act.Should()
                .Throw<ErroAoValidarException>()
                .WithMessage("Nome não pode ser nulo ou vazio.");
        }

        [Fact]
        public void Erro_Ao_Passar_Email_Vazio()
        {
            Action act = () => new Domain.Entities.Aluno("teste", "");

            act.Should()
                .Throw<ErroAoValidarException>()
                .WithMessage("Email não pode ser nulo ou vazio.");
        }

        [Fact]
        public void Sucesso_Ao_Atualizar_Nome()
        {
            var nome = "Teste";
            var email = "teste@gmail.com";

            var entity = new Domain.Entities.Aluno(nome, email);

            entity.AtualizarNome("Atualizando Nome");

            entity.Nome.Should().Be("Atualizando Nome");
            entity.Email.Should().Be(email);
        }

        [Fact]
        public void Sucesso_Ao_Atualizar_Email()
        {
            var nome = "Teste";
            var email = "teste@gmail.com";

            var entity = new Domain.Entities.Aluno(nome, email);

            entity.AtualizarEmail("Atualizando Email");

            entity.Nome.Should().Be(nome);
            entity.Email.Should().Be("Atualizando Email");
        }
    }
}

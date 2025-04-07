using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SenffMensageria.Domain.Enum;
using SenffMensageria.Domain.Exceptions;

namespace SenffMensageria.Tests.Matricula.Entity
{
    public class MatriculaTests
    {
        [Fact]
        public void Sucesso_Ao_Criar()
        {
            var turma = "Turma 1";

            var matricula = new Domain.Entities.Matricula(1, turma);

            matricula.Should().NotBeNull();
            matricula.Turma.Should().Be(turma);
            matricula.AlunoId.Should().Be(1);
            matricula.Status.Should().Be(EStatusMatricula.PREMATRICULA);
        }

        [Fact]
        public void Erro_Ao_Passar_Turma_Vazia()
        {
            Action act = () => new Domain.Entities.Matricula(1, "");

            act.Should().Throw<ErroAoValidarException>()
               .WithMessage("Nome não pode ser nulo ou vazio.");
        }

        [Fact]
        public void Sucesso_Ao_EfetivarMatricula()
        {
            var turma = "Turma 1";

            var matricula = new Domain.Entities.Matricula(1, turma);

            matricula.EfetivarMatricula();

            matricula.Should().NotBeNull();
            matricula.Status.Should().Be(EStatusMatricula.MATRICULADO);
        }

        [Fact]
        public void Erro_Ao_Tentar_Efetivar_Matricula_Com_Status_Diferente_PreMatricula()
        {
            var turma = "Turma 1";
            var matricula = new Domain.Entities.Matricula(1, turma, EStatusMatricula.MATRICULADO);

            matricula.Invoking(m => m.EfetivarMatricula())
                     .Should().Throw<ErroAoValidarException>()
                     .WithMessage("Só efetivar matricula com status pre-matriculado");
        }
        [Fact]
        public void Sucesso_Ao_Cancelar_Matricula()
        {
            var turma = "Turma 1";

            var matricula = new Domain.Entities.Matricula(1, turma);

            matricula.CancelarMatricula();

            matricula.Should().NotBeNull();
            matricula.Status.Should().Be(EStatusMatricula.CANCELADO);
        }
    }
}

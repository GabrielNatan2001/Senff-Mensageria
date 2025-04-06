using System.Xml.Linq;
using SenffMensageria.Domain.Enum;

namespace SenffMensageria.Domain.Entities
{
    public class Matricula : BaseEntity
    {
        public string Turma { get; private set; }
        public EStatusMatricula Status { get; private set; }

        public int AlunoId { get; private set; }
        public Aluno Aluno { get; set; }

        public Matricula(int alunoId, string turma, EStatusMatricula status)
        {
            AlunoId = alunoId;
            Turma = turma;
            Status = EStatusMatricula.PREMATRICULA;
        }

        public void EfetivarMatricula()
        {
            if (Status != EStatusMatricula.PREMATRICULA) throw new Exception("Só efetivar matricula com status pre-matriculado");

            Status = EStatusMatricula.MATRICULADO;
        }
        public void CancelarMatricula()
        {
            Status = EStatusMatricula.CANCELADO;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Turma)) throw new Exception("Nome não pode ser nulo ou vazio.");
        }
    }
}

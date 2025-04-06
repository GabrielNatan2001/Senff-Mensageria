using SenffMensageria.Domain.Enum;

namespace Shared.DTO
{
    public class MatriculaDto
    {
        public int Id { get; set; } 
        public string Turma { get; set; }
        public EStatusMatricula Status { get; set; }

        public int AlunoId { get; set; }
    }
}

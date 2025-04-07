using Shared.DTO;

namespace SenffMensageria.Application.UseCase.Matricula
{
    public interface IMatriculaService
    {
        Task<MatriculaDto> Adicionar(MatriculaDto matricula);
        Task<MatriculaDto> GetById(int id);
    }
}

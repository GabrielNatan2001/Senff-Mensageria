using FluentValidation;
using Shared.DTO;

namespace SenffMensageria.Application.UseCase.Matricula
{
    public class MatriculaValidator : AbstractValidator<MatriculaDto>
    {
        public MatriculaValidator()
        {
            RuleFor(p => p.Turma)
                .NotEmpty().WithMessage("Turma não pode ser nulo ou vazio."); 
            
            RuleFor(p => p.AlunoId)
                .NotEmpty().WithMessage("AlunoId não pode ser vazio");
        }
    }
}

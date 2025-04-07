using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shared.DTO;

namespace SenffMensageria.Application.UseCase.Aluno
{
    public class AlunoValidator : AbstractValidator<AlunoDto>
    {
        public AlunoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome não pode ser nulo ou vazio.");
            RuleFor(p => p.Email)
                 .NotEmpty().WithMessage("Email não pode ser nulo ou vazio.");


        }
    }
}

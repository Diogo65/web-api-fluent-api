using FluentValidation;
using WebApiVagas.Models.Entities;

namespace WebApiVagas.Models.Validation
{
    public class VagaValidator : AbstractValidator<Vaga>
    {
        public VagaValidator()
        {
            //as classes de validação são utilizadas no controller
            RuleFor(v => v.Titulo)
                .NotEmpty().WithMessage("O título da vaga deve ser preenchido.")
                .Length(10, 100).WithMessage("O título da vaga deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(v => v.Descricao)
                .NotEmpty().WithMessage("A descrição da vaga deve ser preenchida.")
                .Length(10, 200).WithMessage("A descrição da vaga deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(v => v.Salario)
                .GreaterThan(0).WithMessage("O salário deve ser maior que zero.");

            RuleFor(v => v.LocalTrabalho)
                .Length(10, 100).WithMessage("O local de trabalho da vaga deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
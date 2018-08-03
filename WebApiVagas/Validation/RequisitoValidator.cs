using FluentValidation;
using WebApiVagas.Models.Entities;

namespace WebApiVagas.Models.Validation
{
    //nuget- install FluentValidation
    public class RequisitoValidator : AbstractValidator<Requisito>
    {
        //No contrutor definimos as regras de validação da entidade
        public RequisitoValidator()
        {
            //row for recebe a propriedade a ser validada
            RuleFor(r => r.Descricao)
                .NotEmpty().WithMessage("A descrição do requisito deve ser informada.")
                .Length(10, 100).WithMessage("A descrição do requisito deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
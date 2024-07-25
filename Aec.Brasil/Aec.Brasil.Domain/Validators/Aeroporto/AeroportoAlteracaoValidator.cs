using FluentValidation;
using FluentValidation.Results;
using System;

namespace Aec.Brasil.Domain.Validators.Aeroporto
{
    public class AeroportoAlteracaoValidator : AbstractValidator<Entities.Aeroporto>, IAeroportoAlteracaoValidator
    {
        public AeroportoAlteracaoValidator()
        {
            RuleFor(a => a.AlteradoEm).NotNull().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.AlteradoEm).NotEqual(new DateTime()).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.AlteradoPor).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");

            RuleFor(a => a.Id).NotEqual(Guid.Empty).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.CodigoIcao).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(x => x.CodigoIcao).MaximumLength(4).WithMessage("O atributo {PropertyName} deve ter no máximo 4 caractéres");
            RuleFor(a => a.Visibilidade).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Visibilidade).MaximumLength(20).WithMessage("O atributo {PropertyName} deve ter no máximo 20 caractéres");
            RuleFor(a => a.Condicao).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Condicao).MaximumLength(2).WithMessage("O atributo {PropertyName} deve ter no máximo 2 caractéres");
            RuleFor(a => a.CondicaoDesc).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.CondicaoDesc).MaximumLength(50).WithMessage("O atributo {PropertyName} deve ter no máximo 50 caractéres");
            RuleFor(a => a.AtualizadoEm).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.AtualizadoEm).NotEqual(new DateTime()).WithMessage("O atributo {PropertyName} é obrigatório");
        }

        public ValidationResult Validar(Entities.Aeroporto instance)
        {
            return Validate(instance);
        }
    }
}

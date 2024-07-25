using FluentValidation;
using FluentValidation.Results;
using System;

namespace Aec.Brasil.Domain.Validators.Cidade
{
    public class CidadeCriacaoValidator : AbstractValidator<Entities.Cidade>, ICidadeCriacaoValidator
    {
        public CidadeCriacaoValidator()
        {
            RuleFor(a => a.CriadoEm).NotEqual(new DateTime()).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.CriadoPor).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");

            RuleFor(a => a.Id).NotEqual(Guid.Empty).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.IdIntegracao).GreaterThan(0).WithMessage("O atributo {PropertyName} deve ser maior que 0(zero)");
            RuleFor(a => a.Nome).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(x => x.Nome).MaximumLength(250).WithMessage("O atributo {PropertyName} deve ter no máximo 250 caractéres");
            RuleFor(a => a.Estado).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(x => x.Estado).MaximumLength(2).WithMessage("O atributo {PropertyName} deve ter no máximo 2 caractéres");
        }

        public ValidationResult Validar(Entities.Cidade instance)
        {
            return Validate(instance);
        }
    }
}

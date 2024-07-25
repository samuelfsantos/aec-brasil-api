using FluentValidation;
using FluentValidation.Results;
using System;

namespace Aec.Brasil.Domain.Validators.Clima
{
    public class ClimaAlteracaoValidator : AbstractValidator<Entities.Clima>, IClimaAlteracaoValidator
    {
        public ClimaAlteracaoValidator()
        {
            RuleFor(a => a.AlteradoEm).NotNull().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.AlteradoEm).NotEqual(new DateTime()).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.AlteradoPor).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");

            RuleFor(a => a.Id).NotEqual(Guid.Empty).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Data).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Data).NotEqual(new DateTime()).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Condicao).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Condicao).MaximumLength(2).WithMessage("O atributo {PropertyName} deve ter no máximo 2 caractéres");
            RuleFor(a => a.CondicaoDesc).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.CondicaoDesc).MaximumLength(50).WithMessage("O atributo {PropertyName} deve ter no máximo 50 caractéres");
            RuleFor(a => a.Min).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Max).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.IndiceUV).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");

            RuleFor(a => a.IdCidade).NotEqual(Guid.Empty).WithMessage("O atributo {PropertyName} é obrigatório");
        }

        public ValidationResult Validar(Entities.Clima instance)
        {
            return Validate(instance);
        }
    }
}

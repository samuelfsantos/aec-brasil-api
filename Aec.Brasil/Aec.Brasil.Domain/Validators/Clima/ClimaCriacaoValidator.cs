﻿using FluentValidation;
using FluentValidation.Results;
using System;

namespace Aec.Brasil.Domain.Validators.Clima
{
    public class ClimaCriacaoValidator : AbstractValidator<Entities.Clima>, IClimaCriacaoValidator
    {
        public ClimaCriacaoValidator()
        {
            RuleFor(a => a.CriadoEm).NotEqual(new DateTime()).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.CriadoPor).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");

            RuleFor(a => a.Id).NotEqual(Guid.Empty).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Data).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Data).NotEqual(new DateTime()).WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Condicao).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.Condicao).MaximumLength(2).WithMessage("O atributo {PropertyName} deve ter no máximo 2 caractéres");
            RuleFor(a => a.CondicaoDesc).NotEmpty().WithMessage("O atributo {PropertyName} é obrigatório");
            RuleFor(a => a.CondicaoDesc).MaximumLength(50).WithMessage("O atributo {PropertyName} deve ter no máximo 50 caractéres");

            RuleFor(a => a.IdCidade).NotEqual(Guid.Empty).WithMessage("O atributo {PropertyName} é obrigatório");
        }

        public ValidationResult Validar(Entities.Clima instance)
        {
            return Validate(instance);
        }
    }
}

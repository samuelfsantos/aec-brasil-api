using FluentValidation.Results;

namespace Aec.Brasil.Domain.Validators
{
    public interface IAecBrasilValidator<TEntity>
    {
        ValidationResult Validar(TEntity instance);
    }
}

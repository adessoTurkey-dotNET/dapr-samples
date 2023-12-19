using FluentValidation;

namespace Adesso.Dapr.Core.Validation.Abstraction;

public interface IAdessoValidator : IValidator
{
}

public interface IAdessoValidator<in T> : IAdessoValidator, IValidator<T>
{
}
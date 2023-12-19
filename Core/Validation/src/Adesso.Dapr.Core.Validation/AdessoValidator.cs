using FluentValidation;
using Adesso.Dapr.Core.Validation.Abstraction;

namespace Adesso.Dapr.Core.Validation;

public class AdessoValidator<T> : AbstractValidator<T>, IAdessoValidator<T>
{
}
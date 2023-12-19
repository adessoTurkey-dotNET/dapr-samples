using Adesso.Dapr.Core.Common.Abstraction.Exception;

namespace Adesso.Dapr.Core.Domain.Abstraction.Excepotion;

public class AdessoBusinessRuleValidationException : AdessoException
{
    public IAdessoBusinessRule BrokenRule { get; }

    public string Details { get; }

    public AdessoBusinessRuleValidationException(IAdessoBusinessRule brokenRule) : base(brokenRule.Message)
    {
        BrokenRule = brokenRule;
        this.Details = brokenRule.Message;
    }

    public override string ToString()
    {
        return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
    }
}
using Adesso.Dapr.Core.Common.Abstraction.Exception;

namespace Adesso.Dapr.Core.Validation.Abstraction.Exception;

public class AdessoValidationException : AdessoException
{
    public AdessoValidationException(int errorCode) : base(errorCode)
    {
    }

    public AdessoValidationException(string message) : base(message)
    {
    }
}
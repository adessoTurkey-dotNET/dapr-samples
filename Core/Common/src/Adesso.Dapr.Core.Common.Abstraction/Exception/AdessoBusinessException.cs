using Adesso.Dapr.Core.Common.Abstraction.Exception;

namespace Adesso.Core.Infrastructure.Exception;

public class AdessoBusinessException : AdessoException
{

    public AdessoBusinessException(int errorCode) : base(errorCode)
    {
    }
    
    public AdessoBusinessException(string message) : base(message)
    {
    }
}
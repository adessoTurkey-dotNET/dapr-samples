using NLocalizator;

namespace Adesso.Dapr.Core.Common.Abstraction.Exception;

public class AdessoException : System.Exception, ILocalizationBook
{
    public int ErrorCode { get; set; }
    public bool IsRollback { get; set; } = true;

    public AdessoException(int errorCode)
    {
        ErrorCode = errorCode;
    }

    public AdessoException(string message) : base(message)
    {
        ErrorCode = 9999;
    }
}
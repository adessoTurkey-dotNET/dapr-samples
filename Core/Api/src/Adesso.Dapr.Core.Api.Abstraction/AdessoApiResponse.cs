using Adesso.Dapr.Core.Common.Abstraction.Exception;

namespace Adesso.Dapr.Core.Infrastructure.Api;

public class AdessoResponseHeader
{
    public bool IsSuccess { get; set; }

    public int ErrorCode { get; set; }

    public string ErrorMessage { get; set; }

    public string? ErrorDetails { get; set; }

    public AdessoResponseHeader()
    {
    }

    public static AdessoResponseHeader Success()
    {
        var header = new AdessoResponseHeader();
        header.IsSuccess = true;

        return header;
    }

    public static AdessoResponseHeader Fail(System.Exception ex)
    {
        var header = new AdessoResponseHeader();
        header.IsSuccess = false;
        header.ErrorCode = ex is AdessoException ? ((AdessoException)ex).ErrorCode : 911;
        header.ErrorCode = ex is AdessoException ? ((AdessoException)ex).ErrorCode : 911;
        header.ErrorMessage = ex.Message;
        header.ErrorDetails = ex.StackTrace;

        return header;
    }
}

public class AdessoApiResponse<T> where T : class
{
    public AdessoApiResponse()
    {
    }

    public AdessoApiResponse(AdessoResponseHeader header, T body)
    {
        Header = header;
        Body = body;
    }

    public AdessoResponseHeader Header { get; set; }

    public T Body { get; set; }
}


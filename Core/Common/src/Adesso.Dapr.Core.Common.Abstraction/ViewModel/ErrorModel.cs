namespace Adesso.Dapr.Core.Common.Abstraction.ViewModel;

public enum AdessoErrorCode
{
    errorCodeIsNotFound = 0
}


public class ErrorDescriptionModel
{
    public string Language { get; set; }
    public string Description { get; set; }
}

public class ErrorViewModel
{
    public int ErrorCode { get; set; }
    public List<ErrorDescriptionModel> Errors { get; set; }
}
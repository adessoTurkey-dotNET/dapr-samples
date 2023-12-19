namespace Adesso.Dapr.Core.Domain.Abstraction;

public interface IAdessoBusinessRule
{
    bool IsBroken();

    string Message { get; }
}
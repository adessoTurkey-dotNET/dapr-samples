using MediatR;

namespace Adesso.Dapr.Core.CQRS.Abstraction.Message;

public interface IAdessoRequest<out TResult> : IRequest<TResult>
{
    
}
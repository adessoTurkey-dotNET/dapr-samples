using Adesso.Dapr.Core.CQRS.Abstraction.Message;

namespace Adesso.Dapr.Core.CQRS.Abstraction;

public interface IAdessoCQRSProcessor
{
    Task ProcessAsync(IAdessoCommand command, CancellationToken cancellationToken);

    Task<TResult> ProcessAsync<TResult>(IAdessoRequest<TResult> request, CancellationToken cancellationToken);

    Task<TResult> ProcessAsync<TResult>(IAdessoCommand<TResult> command, CancellationToken cancellationToken);

    Task<TResult> ProcessAsync<TResult>(IAdessoQuery<TResult> query, CancellationToken cancellationToken);
}
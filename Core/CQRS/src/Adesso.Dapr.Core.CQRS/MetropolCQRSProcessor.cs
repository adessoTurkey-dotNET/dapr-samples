using MediatR;
using Adesso.Dapr.Core.CQRS.Abstraction;
using Adesso.Dapr.Core.CQRS.Abstraction.Message;

namespace Adesso.Dapr.Core.CQRS;

internal sealed class AdessoCQRSProcessor : IAdessoCQRSProcessor
{
    private readonly IMediator _mediator;

    public AdessoCQRSProcessor(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public Task ProcessAsync(IAdessoCommand command, CancellationToken cancellationToken)
    {
        return this._mediator.Send(command, cancellationToken);
    }

    public Task<TResult> ProcessAsync<TResult>(IAdessoRequest<TResult> request, CancellationToken cancellationToken)
    {
        return this._mediator.Send(request, cancellationToken);
    }

    public Task<TResult> ProcessAsync<TResult>(IAdessoCommand<TResult> command, CancellationToken cancellationToken)
    {
        return this._mediator.Send(command, cancellationToken);
    }

    public Task<TResult> ProcessAsync<TResult>(IAdessoQuery<TResult> query, CancellationToken cancellationToken)
    {
        return this._mediator.Send(query, cancellationToken);
    }
}
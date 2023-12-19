using Adesso.Dapr.Core.Common.Abstraction.Exception;
using Adesso.Dapr.Core.CQRS.Abstraction.Handler;
using Adesso.Dapr.Core.CQRS.Abstraction.Message;
using Adesso.Dapr.Core.CQRS.Handler;
using Adesso.Dapr.Core.UnitOfWork.Abstraction;

namespace Adesso.Dapr.Core.CQRS.Decorator;

internal sealed class AdessoCommandHandlerDecorator<TCommand, TResult> : AdessoCommandHandler<TCommand, TResult>
    where TCommand : IAdessoCommand<TResult>
{
    private readonly IAdessoCommandHandler<TCommand, TResult> _decorated;

    IEnumerable<IAdessoUnitOfWork> _unitOfWorks;

    public AdessoCommandHandlerDecorator(
        IAdessoCommandHandler<TCommand, TResult> decorated,
        IEnumerable<IAdessoUnitOfWork> unitOfWorks)
    {
        _decorated = decorated;
        _unitOfWorks = unitOfWorks;
    }

    public override async Task<TResult?> Handle(TCommand command, CancellationToken cancellationToken)
    {
        foreach (var unitOfWork in _unitOfWorks)
        {
            await unitOfWork.DbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        try
        {
            var result = await _decorated.Handle(command, cancellationToken);

            foreach (var unitOfWork in _unitOfWorks)
            {
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.DbContext.Database.CommitTransactionAsync(cancellationToken);
            }

            return result;
        }
        catch (System.Exception ex) when (ex is AdessoException { IsRollback: false })
        {
            foreach (var unitOfWork in _unitOfWorks)
            {
                if (unitOfWork.DbContext.Database.CurrentTransaction != null)
                {
                    await unitOfWork.DbContext.Database.CommitTransactionAsync(cancellationToken);
                }
            }

            throw;
        }
        catch (Exception ex)
        {
            foreach (var unitOfWork in _unitOfWorks)
            {
                if (unitOfWork.DbContext.Database.CurrentTransaction != null)
                {
                    await unitOfWork.DbContext.Database.RollbackTransactionAsync(cancellationToken);
                }
            }

            throw;
        }
    }
}
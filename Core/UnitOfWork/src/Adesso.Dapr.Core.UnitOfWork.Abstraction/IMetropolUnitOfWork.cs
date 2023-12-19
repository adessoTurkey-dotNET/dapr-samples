using Microsoft.EntityFrameworkCore;
using MiniUow;

namespace Adesso.Dapr.Core.UnitOfWork.Abstraction;

public interface IAdessoUnitOfWork<TContext> : IAdessoUnitOfWork, IUnitOfWork<TContext>
    where TContext : DbContext
{
}

public interface IAdessoUnitOfWork : IUnitOfWork
{
    public DbContext DbContext { get; }
}
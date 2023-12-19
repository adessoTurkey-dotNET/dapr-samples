using Adesso.Dapr.Core.Domain;
using Adesso.Dapr.Core.UnitOfWork.Abstraction;
using Microsoft.EntityFrameworkCore;
using MiniUow;
using System.Collections.Concurrent;

namespace Adesso.Dapr.Core.UnitOfWork;

public class AdessoUnitOfWork<TContext> : IAdessoUnitOfWork<TContext>, IAdessoUnitOfWork
    where TContext : DbContext
{
    public DbContext DbContext => _unitOfWork.Context;

    public TContext Context => _unitOfWork.Context;

    private readonly IUnitOfWork<TContext> _unitOfWork;
    private readonly ConcurrentDictionary<Type, object> _repositories;

    public AdessoUnitOfWork(IUnitOfWork<TContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repositories = new ConcurrentDictionary<Type, object>();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        var respository = _unitOfWork.GetRepository<TEntity>();
        return new AdessoRepository<TEntity>(respository);
    }

    public int SaveChanges()
    {
        var addedEntities = Context.ChangeTracker
                                 .Entries()
                                 .Where(x => x.State == EntityState.Added && x.Entity.GetType().IsSubclassOf(typeof(AdessoEntityWithAudit)))
                                 .ToList();

        foreach (var entry in addedEntities)
        {
            var entity = entry.Entity as AdessoEntityWithAudit;
            if (entity != null)
            {
                entity.CreateDate = DateTime.Now; // Şu anki zamanı atayabilirsiniz.
            }
        }

        var updatedEntities = Context.ChangeTracker
                             .Entries()
                             .Where(x => x.State == EntityState.Modified && x.Entity.GetType().IsSubclassOf(typeof(AdessoEntityWithAudit)))
                             .ToList();

        foreach (var entry in updatedEntities)
        {
            var entity = entry.Entity as AdessoEntityWithAudit;
            if (entity != null)
            {
                entity.ModifyDate = DateTime.Now; // Güncelleme zamanını atayabilirsiniz.
            }
        }

        var deletedEntities = Context.ChangeTracker
                             .Entries()
                             .Where(x => x.State == EntityState.Deleted && x.Entity.GetType().IsSubclassOf(typeof(AdessoEntityWithAudit)))
                             .ToList();

        foreach (var entry in deletedEntities)
        {
            var entity = entry.Entity as AdessoEntityWithAudit;
            if (entity != null)
            {
                entity.IsDeleted = true;
                entry.State = EntityState.Modified; // Nesnenin durumunu "Modified" (Güncellendi) olarak değiştiriyoruz çünkü artık fiziksel olarak silmiyoruz.
                entity.ModifyDate = DateTime.Now; // Güncelleme zamanını atayabilirsiniz.
            }
        }

        return _unitOfWork.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {

        var addedEntities = Context.ChangeTracker
                                 .Entries()
                                 .Where(x => x.State == EntityState.Added && x.Entity.GetType().IsSubclassOf(typeof(AdessoEntityWithAudit)))
                                 .ToList();

        foreach (var entry in addedEntities)
        {
            var entity = entry.Entity as AdessoEntityWithAudit;
            if (entity != null)
            {
                entity.CreateDate = DateTime.Now; // Şu anki zamanı atayabilirsiniz.
            }
        }

        var updatedEntities = Context.ChangeTracker
                             .Entries()
                             .Where(x => x.State == EntityState.Modified && x.Entity.GetType().IsSubclassOf(typeof(AdessoEntityWithAudit)))
                             .ToList();

        foreach (var entry in updatedEntities)
        {
            var entity = entry.Entity as AdessoEntityWithAudit;
            if (entity != null)
            {
                entity.ModifyDate = DateTime.Now; // Güncelleme zamanını atayabilirsiniz.
            }
        }

        var deletedEntities = Context.ChangeTracker
                             .Entries()
                             .Where(x => x.State == EntityState.Deleted && x.Entity.GetType().IsSubclassOf(typeof(AdessoEntityWithAudit)))
                             .ToList();

        foreach (var entry in deletedEntities)
        {
            var entity = entry.Entity as AdessoEntityWithAudit;
            if (entity != null)
            {
                entity.IsDeleted = true;
                entry.State = EntityState.Modified; // Nesnenin durumunu "Modified" (Güncellendi) olarak değiştiriyoruz çünkü artık fiziksel olarak silmiyoruz.
                entity.ModifyDate = DateTime.Now; // Güncelleme zamanını atayabilirsiniz.
            }
        }
        return _unitOfWork.SaveChangesAsync();
    }
}
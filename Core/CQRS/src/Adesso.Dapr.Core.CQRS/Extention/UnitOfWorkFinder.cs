using Adesso.Dapr.Core.Domain;
using Adesso.Dapr.Core.UnitOfWork.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Adesso.Dapr.Core.Infrastructure.CQRS.Extention;

public static class UnitOfWorkFinder
{
    public static IAdessoUnitOfWork FindUnitOfWorkForEntity<TEntity>(this IEnumerable<IAdessoUnitOfWork> unitOfWorks)
        where TEntity : AdessoEntity
    {
        foreach (var unitOfWork in unitOfWorks)
        {
            var dbContextType = unitOfWork.GetType().GetGenericArguments()[0];
            if (dbContextType.GetProperties()
                .Any(p => p.PropertyType.IsGenericType &&
                          p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                          p.PropertyType.GetGenericArguments()[0] == typeof(TEntity)))
            {
                return unitOfWork;
            }
        }

        return null;
    }
}
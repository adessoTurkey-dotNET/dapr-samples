using Adesso.Dapr.Core.IOC.Abstraction.Service;
using MiniUow;

namespace Adesso.Dapr.Core.UnitOfWork.Abstraction;

public interface IAdessoRepository<TEntity> : IAdessoServiceScope, IRepository<TEntity> where TEntity : class
{

}
using Adesso.Dapr.Core.CQRS.Library;
using Adesso.Dapr.Core.Domain;
using Adesso.Dapr.Core.Infrastructure.Api;
using MiniUow.Paging;

namespace Adesso.Dapr.Core.Api.Abstraction;

public class AdessoGenericRequest<TEntity>
    where TEntity : AdessoEntity
{
    public TEntity Entity { get; set; }

    public List<Filter> Filters { get; set; }
}

public interface IAdessoGenericApi<TEntity>
    where TEntity : AdessoEntity
{
    Task<AdessoApiResponse<TEntity>> GetEntity(int id, CancellationToken cancellationToken);

    Task<AdessoApiResponse<IList<TEntity>>> SearchEntityForList(AdessoGenericRequest<TEntity> search,
        CancellationToken cancellationToken);

    Task<AdessoApiResponse<IPaginate<TEntity>>> SearchEntityForPaged(AdessoGenericRequest<TEntity> search,
        int index, int size, CancellationToken cancellationToken);
}
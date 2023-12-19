using System.Linq.Expressions;
using Adesso.Dapr.Core.Domain;
using Adesso.Dapr.Core.UnitOfWork.Abstraction;
using Microsoft.EntityFrameworkCore.Query;
using MiniUow;
using MiniUow.Paging;

namespace Adesso.Dapr.Core.UnitOfWork;

public class AdessoRepository<TEntity> : IAdessoRepository<TEntity>
    where TEntity : class
{
    public IRepository<TEntity> Repository => _repository;

    private readonly IRepository<TEntity> _repository;

    public AdessoRepository(IRepository<TEntity> repository)
    {
        _repository = repository;
    }


    public decimal Average(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, decimal>> selector = null)
    {
        return _repository.Average(predicate, selector);
    }

    public Task<decimal> AverageAsync(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, decimal>> selector = null)
    {
        return _repository.AverageAsync(predicate, selector);
    }

    public bool Any(Expression<Func<TEntity, bool>> predicate = null)
    {
        return _repository.Any(predicate);
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        return _repository.AnyAsync(predicate);
    }

    public int Count(Expression<Func<TEntity, bool>> predicate = null)
    {
        return _repository.Count(predicate);
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        return _repository.CountAsync(predicate);
    }

    public bool Exists(Expression<Func<TEntity, bool>> selector = null)
    {
        return _repository.Exists(selector);
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> selector = null)
    {
        return _repository.ExistsAsync(selector);
    }

    public TEntity Find(params object[] keyValues)
    {
        return _repository.Find(keyValues);
    }

    public Task<TEntity> FindAsync(params object[] keyValues)
    {
        return Task.Factory.StartNew(() => _repository.Find(keyValues));
    }

    public Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
    {
        return Task.Factory.StartNew(() => _repository.Find(keyValues), cancellationToken);
    }

    public TResult FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.FirstOrDefault(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        return _repository.FirstOrDefault(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public TEntity FirstOrDefault(string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        return _repository.FirstOrDefault(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        return _repository.FirstOrDefaultAsync(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public TResult FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector, string predicate = null,
        string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.FirstOrDefault(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.FirstOrDefaultAsync(selector, predicate, orderBy, include, disableTracking,
            ignoreQueryFilters);
    }

    public Task<TEntity> FirstOrDefaultAsync(string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        return _repository.FirstOrDefaultAsync(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.FirstOrDefaultAsync(selector, predicate, orderBy, include, disableTracking,
            ignoreQueryFilters);
    }

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        return _repository.GetAll(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public IQueryable<TEntity> GetAll(string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        return _repository.GetAll(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.GetAll(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector, string predicate = null,
        string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.GetAll(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        return _repository.GetAllAsync(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public Task<IQueryable<TEntity>> GetAllAsync(string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        return _repository.GetAllAsync(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public Task<IQueryable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.GetAllAsync(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public Task<IQueryable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.GetAllAsync(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public IPaginate<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0,
        int size = 20, bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        return _repository.GetPagedList(predicate, orderBy, include, index, size, disableTracking, ignoreQueryFilters);
    }

    public IPaginate<TEntity> GetPagedList(string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0,
        int size = 20, bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        return _repository.GetPagedList(predicate, orderBy, include, index, size, disableTracking, ignoreQueryFilters);
    }

    public IPaginate<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 20,
        bool disableTracking = true, bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.GetPagedList(selector, predicate, orderBy, include, index, size, disableTracking,
            ignoreQueryFilters);
    }

    public Task<IPaginate<TEntity>> GetPagedListAsync(string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0,
        int size = 20, bool disableTracking = true, CancellationToken cancellationToken = new CancellationToken(),
        bool ignoreQueryFilters = false)
    {
        return _repository.GetPagedListAsync(predicate, orderBy, include, index, size, disableTracking,
            cancellationToken, ignoreQueryFilters);
    }

    public Task<IPaginate<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0,
        int size = 20, bool disableTracking = true, CancellationToken cancellationToken = new CancellationToken(),
        bool ignoreQueryFilters = false)
    {
        return _repository.GetPagedListAsync(predicate, orderBy, include, index, size, disableTracking,
            cancellationToken, ignoreQueryFilters);
    }

    public IPaginate<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
        string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 20,
        bool disableTracking = true, bool ignoreQueryFilters = false) where TResult : class
    {
        return _repository.GetPagedList(selector, predicate, orderBy, include, index, size, disableTracking,
            ignoreQueryFilters);
    }

    public Task<IPaginate<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 0,
        int pageSize = 20, bool disableTracking = true,
        CancellationToken cancellationToken = new CancellationToken(), bool ignoreQueryFilters = false)
        where TResult : class
    {
        return _repository.GetPagedListAsync(selector, predicate, orderBy, include, pageIndex, pageSize,
            disableTracking, cancellationToken, ignoreQueryFilters);
    }

    public Task<IPaginate<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        string predicate = null, string orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 0,
        int pageSize = 20, bool disableTracking = true,
        CancellationToken cancellationToken = new CancellationToken(), bool ignoreQueryFilters = false)
        where TResult : class
    {
        return _repository.GetPagedListAsync(selector, predicate, orderBy, include, pageIndex, pageSize,
            disableTracking, cancellationToken, ignoreQueryFilters);
    }

    public long LongCount(Expression<Func<TEntity, bool>> predicate = null)
    {
        return _repository.LongCount(predicate);
    }

    public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        return _repository.LongCountAsync(predicate);
    }

    public TEntity1 Max<TEntity1>(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, TEntity1>> selector = null)
    {
        return _repository.Max(predicate, selector);
    }

    public Task<TEntity1> MaxAsync<TEntity1>(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, TEntity1>> selector = null)
    {
        return _repository.MaxAsync(predicate, selector);
    }

    public TEntity1 Min<TEntity1>(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, TEntity1>> selector = null)
    {
        return _repository.Min(predicate, selector);
    }

    public Task<TEntity1> MinAsync<TEntity1>(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, TEntity1>> selector = null)
    {
        return _repository.MinAsync(predicate, selector);
    }

    public IQueryable<TEntity> Query(string sql, params object[] parameters)
    {
        return _repository.Query(sql, parameters);
    }

    public TEntity Single(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        return _repository.Single(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        return _repository.SingleAsync(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
    }

    public decimal Sum(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, decimal>> selector = null)
    {
        return _repository.Sum(predicate, selector);
    }

    public Task<decimal> SumAsync(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, decimal>> selector = null)
    {
        return _repository.SumAsync(predicate, selector);
    }

    public void Dispose()
    {
        _repository.Dispose();
    }

    public int ExecuteSqlCommand(string sql, params object[] parameters)
    {
        return _repository.ExecuteSqlCommand(sql, parameters);
    }

    public TEntity Add(TEntity entity)
    {
        return _repository.Add(entity);
    }

    public void Add(params TEntity[] entities)
    {
        _repository.Add(entities);
    }

    public void Add(IEnumerable<TEntity> entities)
    {
        _repository.Add(entities);
    }

    public Task AddAsync(params TEntity[] entities)
    {
        return _repository.AddAsync(entities);
    }

    public Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = new CancellationToken())
    {
        return _repository.AddAsync(entities, cancellationToken);
    }

    public void Delete(TEntity entity)
    {
        _repository.Delete(entity);
    }

    public void Delete(object id)
    {
        _repository.Delete(id);
    }

    public void Delete(params TEntity[] entities)
    {
        _repository.Delete(entities);
    }

    public void Delete(IEnumerable<TEntity> entities)
    {
        _repository.Delete(entities);
    }

    public TEntity Update(TEntity entity)
    {
        return _repository.Update(entity);
    }

    public void Update(params TEntity[] entities)
    {
        _repository.Update(entities);
    }

    public void Update(IEnumerable<TEntity> entities)
    {
        _repository.Update(entities);
    }
}
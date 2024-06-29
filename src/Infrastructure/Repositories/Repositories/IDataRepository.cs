using Rabbot.Jedi.Data.Searching;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Music.IO.Data.Repository
{
    public interface IDataRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : class
    {
        IDataContext Context { get; }
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TKey id, EntityStatusFilter status, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAsync(CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAsync(EntityStatusFilter status, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, EntityStatusFilter status, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, EntityStatusFilter status, SearchDataPagination? pagination, CancellationToken cancellationToken = default);
        Task<TKey> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DisableAsync(TKey id, CancellationToken cancellationToken = default);
        Task EnableAsync(TKey id, CancellationToken cancellationToken = default);
        Task ReplaceOneAsync(TKey id, TEntity entity, CancellationToken cancellationToken = default);
        Task<SearchDataResponse<TEntity>> SearchAsync(SearchData search, CancellationToken cancellationToken = default);
    }
}

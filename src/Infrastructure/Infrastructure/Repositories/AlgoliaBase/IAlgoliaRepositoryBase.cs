namespace Infrastructure.Repositories.AlgoliaBase
{
    public interface IAlgoliaRepositoryBase<T>
    {
        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<string> AddAsync(T entity, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
    }
}

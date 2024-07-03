namespace Infrastructure.Repositories.Firestore.Base
{
    namespace Infrastructure.Repositories.Firestore.Base
    {
        public interface IFirestoreRepositoryBase<T> where T : class
        {
            Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);
            Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
            Task<string> AddAsync(T entity, CancellationToken cancellationToken);
            Task<bool> UpdateAsync(T entity, string id, CancellationToken cancellationToken);
            Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
        }
    }
}

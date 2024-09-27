using Infrastructure.Entities;

namespace Infrastructure.Repositories.Firestore
{
    public interface ITransactionRepository
    {
        Task<string> Create(Transaction transaction, CancellationToken cancellationToken);
        Task<Transaction> GetById(string id, CancellationToken cancellationToken);
        Task<bool> Update(string id, Transaction transaction, CancellationToken cancellationToken);
    }
}

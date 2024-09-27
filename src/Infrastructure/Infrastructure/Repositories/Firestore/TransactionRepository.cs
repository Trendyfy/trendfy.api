using Google.Cloud.Firestore;
using Infrastructure.Repositories.Firestore.Base;
using Transaction = Infrastructure.Entities.Transaction;

namespace Infrastructure.Repositories.Firestore
{
    public class TransactionRepository : FirestoreRepositoryBase<Transaction>, ITransactionRepository
    {
        private readonly FirestoreDb _firestoreDb;

        public TransactionRepository(FirestoreDb firestoreDb) : base(firestoreDb, "users")
        {
            _firestoreDb = firestoreDb;
        }

        public async Task<string> Create(Transaction transaction, CancellationToken cancellationToken)
        {
            var collection = _firestoreDb.Collection("transaction");
            var docRef = collection.Document(transaction.Id);
            await docRef.SetAsync(transaction);
            return docRef.Id;
        }

        public async Task<Transaction> GetById(string id, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(id, cancellationToken);
        }
        public async Task<bool> Update(string id, Transaction transaction, CancellationToken cancellationToken)
        {
            return await UpdateAsync(transaction, id, cancellationToken);
        }       
    }
}

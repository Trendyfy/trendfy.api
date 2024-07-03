using Google.Cloud.Firestore;
using Infrastructure.Repositories.Firestore.Base.Infrastructure.Repositories.Firestore.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Firestore.Base
{
    public class FirestoreRepositoryBase<T> : IFirestoreRepositoryBase<T> where T : class
    {
        private readonly FirestoreDb _firestoreDb;
        private readonly string _collectionName;

        public FirestoreRepositoryBase(FirestoreDb firestoreDb, string collectionName)
        {
            _firestoreDb = firestoreDb;
            _collectionName = collectionName;
        }

        private CollectionReference Collection => _firestoreDb.Collection(_collectionName);

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var document = await Collection.Document(id).GetSnapshotAsync(cancellationToken);
            return document.Exists ? document.ConvertTo<T>() : null;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var snapshot = await Collection.GetSnapshotAsync(cancellationToken);
            return snapshot.Documents.Select(doc => doc.ConvertTo<T>());
        }

        public async Task<string> AddAsync(T entity, CancellationToken cancellationToken)
        {
            var document = await Collection.AddAsync(entity, cancellationToken);
            return document.Id;
        }

        public async Task<bool> UpdateAsync(T entity, string id, CancellationToken cancellationToken)
        {
            var document = Collection.Document(id);
            var result = await document.SetAsync(entity, SetOptions.Overwrite, cancellationToken);
            return result.UpdateTime != null;
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var document = Collection.Document(id);
            var result = await document.DeleteAsync();
            return result.UpdateTime != null;
        }
    }
}

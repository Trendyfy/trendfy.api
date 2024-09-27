using Google.Cloud.Firestore;
using Infrastructure.Entities;
using Infrastructure.Repositories.Firestore.Base;

namespace Infrastructure.Repositories.Firestore
{
    public class UserRepository : FirestoreRepositoryBase<User>, IUserRepository
    {
        private readonly FirestoreDb _firestoreDb;

        public UserRepository(FirestoreDb firestoreDb) : base(firestoreDb, "users")
        {
            _firestoreDb = firestoreDb;
        }

        public async Task<string> AddUserAsync(User user, CancellationToken cancellationToken)
        {
            var collection = _firestoreDb.Collection("users");
            var docRef = collection.Document(user.Id);
            await docRef.SetAsync(user);
            return docRef.Id;
        }

        public async Task<User> GetUserByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await GetAllAsync(cancellationToken);
        }

        public async Task<bool> UpdateUserAsync(string id, User user, CancellationToken cancellationToken)
        {
            return await UpdateAsync(user, id, cancellationToken);
        }

        public async Task<bool> DeleteUserAsync(string id, CancellationToken cancellationToken)
        {
            return await DeleteAsync(id, cancellationToken);
        }
    }

}

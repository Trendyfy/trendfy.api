using Infrastructure.Entities;

namespace Infrastructure.Repositories.Firestore
{
    public interface IUserRepository
    {
        Task<string> AddUserAsync(User user, CancellationToken cancellationToken);
        Task<User> GetUserByIdAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<bool> UpdateUserAsync(string id, User user, CancellationToken cancellationToken);
        Task<bool> DeleteUserAsync(string id, CancellationToken cancellationToken);
    }
}

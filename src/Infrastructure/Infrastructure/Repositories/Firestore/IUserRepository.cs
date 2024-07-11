using Infrastructure.Entities;

namespace Infrastructure.Repositories.Firestore
{
    public interface IUserRepository
    {
        Task<string> AddUserAsync(User user, CancellationToken cancellationToken);
        Task<User> GetUserByIdAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task UpdateUserAsync(string id, User user, CancellationToken cancellationToken);
        Task DeleteUserAsync(string id, CancellationToken cancellationToken);
    }
}

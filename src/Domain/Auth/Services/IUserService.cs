using Auth.Models;
using Infrastructure.Entities;

namespace Auth.Services
{
    public interface IUserService
    {
        Task<string> RegisterUserAsync(UserRequest userRequest, CancellationToken cancellationToken);
        Task<string> ResetPasswordAsync(string email, CancellationToken cancellationToken);
        Task<User> GetUserById(string id, CancellationToken cancellationToken);
    }
}

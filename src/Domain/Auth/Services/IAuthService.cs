using Auth.Models;

namespace Auth.Services
{
    public interface IAuthService
    {
        Task<string> RegisterUserAsync(UserRequest userRequest, CancellationToken cancellationToken);
        Task<string> ResetPasswordAsync(string email, CancellationToken cancellationToken);
    }
}

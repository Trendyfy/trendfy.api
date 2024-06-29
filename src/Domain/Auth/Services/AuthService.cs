namespace Auth.Services
{
    using Auth.Models;
    using FirebaseAdmin.Auth;
    using System.Threading.Tasks;

    public class AuthService : IAuthService
    {
        public async Task<string> RegisterUserAsync(UserRequest user, CancellationToken cancellationToken)
        {
            var userRecordArgs = new UserRecordArgs
            {
                Email = user.Email,
                EmailVerified = true,
                Password = user.Password,
                Disabled = false,
            };

            var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userRecordArgs);
            return userRecord.Uid;
        }
        public async Task<string> ResetPasswordAsync(string email, CancellationToken cancellationToken)
        {
            return await FirebaseAuth.DefaultInstance.GeneratePasswordResetLinkAsync(email);
        }
    }
}

namespace Auth.Services
{
    using Auth.Models;
    using FirebaseAdmin.Auth;
    using Infrastructure.Entities;
    using Infrastructure.Repositories.Firestore;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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

            return await _userRepository.AddUserAsync(
                new Infrastructure.Entities.User()
                {
                    Id = userRecord.Uid,
                    Email = user.Email,
                    CreatedAt = DateTime.UtcNow,
                },
                cancellationToken);
        }
        public async Task<string> ResetPasswordAsync(string email, CancellationToken cancellationToken)
        {


            return await FirebaseAuth.DefaultInstance.GeneratePasswordResetLinkAsync(email);
        }

        public async Task<User> GetUserById(string id, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(id, cancellationToken);
        }

        public Task<bool> CreateUserTransaction(string userId, string transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddCredits(string transactionId, string userId, long amount)
        {
            throw new NotImplementedException();
        }
    }
}

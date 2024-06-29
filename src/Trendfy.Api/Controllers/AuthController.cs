using Auth.Models;
using Auth.Services;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using MusicAssistentAI.Interfaces;
using MusicManager.Models;

namespace Trendfy.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("user/register")]
        public async Task<IActionResult> Register([FromBody] UserRequest user, CancellationToken cancellationToken)
        {
            if (user == null)
                return BadRequest();

            var result = await _authService.RegisterUserAsync(user, cancellationToken);
            return CreatedAtAction(nameof(Register), result);
        }

        [HttpPost("user/reset/{email}")]
        public async Task<IActionResult> ResetPassword(string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            var result = await _authService.ResetPasswordAsync(email, cancellationToken);
            return CreatedAtAction(nameof(ResetPassword), result);
        }
    }
}

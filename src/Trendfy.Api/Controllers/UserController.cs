using Auth.Models;
using Auth.Services;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using MusicAssistentAI.Interfaces;
using MusicManager.Models;

namespace Trendfy.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService authService)
        {
            _userService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest user, CancellationToken cancellationToken)
        {
            if (user == null)
                return BadRequest();

            var result = await _userService.RegisterUserAsync(user, cancellationToken);
            return CreatedAtAction(nameof(Register), result);
        }

        [HttpPost("reset/{email}")]
        public async Task<IActionResult> ResetPassword(string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            var result = await _userService.ResetPasswordAsync(email, cancellationToken);
            return CreatedAtAction(nameof(ResetPassword), result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var result = await _userService.GetUserById(id, cancellationToken);
            return CreatedAtAction(nameof(GetUserById), result);
        }
    }
}

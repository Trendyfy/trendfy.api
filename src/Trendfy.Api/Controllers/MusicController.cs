using Microsoft.AspNetCore.Mvc;
using MusicAssistentAI.Interfaces;
using MusicManager.Models;

namespace Trendfy.Api.Controllers
{
    [ApiController]
    [Route("music")]
    public class MusicController : ControllerBase
    {
        private readonly IComposeMusicService _musicComposer;
        public MusicController(IComposeMusicService musicComposer)
        {
            _musicComposer = musicComposer;
        }

        [HttpPost("make")]
        public async Task<IActionResult> CreateMusic([FromBody] CreateMusicRequest music, CancellationToken cancellationToken)
        {
            if (music == null)
                return BadRequest();

            var result = await _musicComposer.CreateMusicAsync(music, cancellationToken);
            return CreatedAtAction(nameof(CreateMusic), result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusicById(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var result = await _musicComposer.GetMusicByIdAsync(id, cancellationToken);
            return CreatedAtAction(nameof(CreateMusic), result);
        }

        [HttpGet("search")]
        public async Task<ActionResult> Search([FromQuery] string query, CancellationToken cancellationToken)
        {
            var (results, facets) = await _musicComposer.SearchMusicTracksAsync(query, cancellationToken);
            return Ok(new { Results = results, Facets = facets });
        }

    }
}

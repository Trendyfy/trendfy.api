using ComposerManager.Models;
using Microsoft.AspNetCore.Mvc;
using MusicManager.Services;

namespace Trendfy.Api.Controllers
{
    [ApiController]
    [Route("music")]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet("{id}")]
        public IActionResult GetMusicById(Guid id)
        {
            var music = _musicService.GetMusicById(id);
            if (music == null)
            {
                return NotFound();
            }
            return Ok(music);
        }

        [HttpGet]
        public IActionResult GetAllMusics()
        {
            var musics = _musicService.GetAllMusics();
            return Ok(musics);
        }

        [HttpPost]
        public IActionResult CreateMusic([FromBody] Music music)
        {
            if (music == null)
            {
                return BadRequest();
            }
            _musicService.CreateMusic(music);
            return CreatedAtAction(nameof(GetMusicById), new { id = music.MusicId }, music);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMusic(Guid id, [FromBody] Music music)
        {
            if (music == null || music.MusicId != id)
            {
                return BadRequest();
            }
            var existingMusic = _musicService.GetMusicById(id);
            if (existingMusic == null)
            {
                return NotFound();
            }
            _musicService.UpdateMusic(music);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMusic(Guid id)
        {
            var music = _musicService.GetMusicById(id);
            if (music == null)
            {
                return NotFound();
            }
            _musicService.DeleteMusic(id);
            return NoContent();
        }
    }
}

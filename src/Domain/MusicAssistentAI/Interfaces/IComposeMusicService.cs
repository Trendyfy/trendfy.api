using Infrastructure.Entities;
using Infrastructure.Models.AI;
using MusicManager.Models;

namespace MusicAssistentAI.Interfaces
{
    public interface IComposeMusicService
    {
        public Task<List<MusicResponse>> CreateMusicAsync(CreateMusicRequest prompt, CancellationToken cancellationToken);
        public Task<MusicResponse> GetMusicByIdAsync(string id, CancellationToken cancellationToken);
        Task<(IEnumerable<Music> Hits, Dictionary<string, Dictionary<string, long>> Facets)> SearchMusicTracksAsync(string query, CancellationToken cancellationToken);
    }
}

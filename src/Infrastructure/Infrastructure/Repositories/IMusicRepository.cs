using Infrastructure.Entities;
using Infrastructure.Repositories.AlgoliaBase;

namespace Infrastructure.Repositories
{
    public interface IMusicRepository : IAlgoliaRepositoryBase<Music>
    {
        Task<(IEnumerable<Music> Hits, Dictionary<string, Dictionary<string, long>> Facets)> SearchMusicTracksAsync(string query, CancellationToken cancellationToken);
    }
}

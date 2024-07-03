using Infrastructure.Entities;
using Infrastructure.Repositories.Algolia.Base;

namespace Infrastructure.Repositories.Algolia
{
    public interface IMusicAlgoliaRepository : IAlgoliaRepositoryBase<Music>
    {
        Task<(IEnumerable<Music> Hits, Dictionary<string, Dictionary<string, long>> Facets)> SearchMusicTracksAsync(string query, CancellationToken cancellationToken);
    }
}

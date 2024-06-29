using Algolia.Search.Clients;
using Algolia.Search.Models.Search;
using Infrastructure.Entities;
using Infrastructure.Repositories.AlgoliaBase;

namespace Infrastructure.Repositories
{
    public class MusicRepository : AlgoliaRepositoryBase<Music>, IMusicRepository
    {
        private const string indexName = "trendify-music";
        private readonly ISearchIndex _index;
        public MusicRepository(ISearchClient client) : base(client, indexName)
        {
            _index = client.InitIndex(indexName);
        }

        public async Task<(IEnumerable<Music> Hits, Dictionary<string, Dictionary<string, long>> Facets)> SearchMusicTracksAsync(string query, CancellationToken cancellationToken)
        {
            var searchResult = await _index.SearchAsync<Music>(new Query
            {
                SearchQuery = query,
                Facets = new List<string> { "tags" },
                HitsPerPage = 1000
            }, ct: cancellationToken);

            var hits = searchResult.Hits;
            var facets = searchResult.Facets;

            return (hits, facets);
        }
    }
}

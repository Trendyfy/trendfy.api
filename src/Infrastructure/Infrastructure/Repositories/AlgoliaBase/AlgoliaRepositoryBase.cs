using Algolia.Search.Clients;
using Algolia.Search.Http;
using Algolia.Search.Models.Search;

namespace Infrastructure.Repositories.AlgoliaBase
{
    public class AlgoliaRepositoryBase<T> : IAlgoliaRepositoryBase<T> where T : class
    {
        private readonly ISearchIndex _index;

        public AlgoliaRepositoryBase(ISearchClient client, string indexName)
        {
            _index = client.InitIndex(indexName);
        }

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _index.GetObjectAsync<T>(id, ct: cancellationToken);
            return response;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _index.SearchAsync<T>(new Query { SearchQuery = "", HitsPerPage = 1000 }, ct: cancellationToken);
            return response.Hits;
        }

        public async Task<string> AddAsync(T entity, CancellationToken cancellationToken)
        {
            var response = await _index.SaveObjectAsync(entity, new RequestOptions() { }, ct: cancellationToken);
            return response.Responses[0].ObjectIDs.First();
        }

        public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            var response = await _index.PartialUpdateObjectAsync(entity, createIfNotExists: true, ct: cancellationToken);
            return response.TaskID > 0;
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _index.DeleteObjectAsync(id, ct: cancellationToken);
            return response.TaskID > 0;
        }
    }
}

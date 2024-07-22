using Newtonsoft.Json;
using PaymentProvider.Providers.Cora.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaymentProvider.Providers.Cora
{
    public interface IAuthenticationCoraService
    {
        Task<string> GetTokenAsync(CancellationToken cancellationToken);
    }

    public class AuthenticationCoraService : IAuthenticationCoraService
    {
        private readonly HttpClient _client;

        public AuthenticationCoraService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CoraClient");
        }

        public async Task<string> GetTokenAsync(CancellationToken cancellationToken)
        {
            var parameters = new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" },
                    { "client_id", "int-37Wj955YaT8ip5HqWITFoI" }
                };

            var content = new FormUrlEncodedContent(parameters);

            try
            {
                var response = await _client.PostAsync("token", content, cancellationToken);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<CoraTokenResponse>(jsonResponse);
                return tokenResponse.AccessToken;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                throw;
            }
        }

    }


}

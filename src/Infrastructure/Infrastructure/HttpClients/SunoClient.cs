namespace Infrastructure.HttpClients
{
    using Infrastructure.HttpClients.Interfaces;
    using Infrastructure.Models.AI;
    using MusicAssistentAI.Models.AI;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using static Google.Apis.Requests.BatchRequest;

    public class SunoClient : ISunoClient
    {
        private readonly HttpClient _client;
        private readonly string _url;
        private readonly string _apiKey;

        public SunoClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<AIMusicTrackResponse>> GenerateSimpleTrackAsync(AIComposeSimple prompt, CancellationToken cancellationToken)
        {
            var jsonPayload = JsonConvert.SerializeObject(prompt);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync($"{_url}/generate", content);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AIMusicTrackResponse>>(jsonResponse);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                throw;
            }
        }
        public async Task<List<AIMusicTrackResponse>> GenerateCustomTrackAsync(AIComposeCustom prompt, CancellationToken cancellationToken)
        {
            var jsonPayload = JsonConvert.SerializeObject(prompt);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync($"{_url}/generate/custom-mode", content);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AIMusicTrackResponse>>(jsonResponse);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                throw;
            }
        }
        public async Task<AIMusicTrackResponse?> GetMusicByIdAsync(string id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _client.GetAsync($"{_url}/?ids[0]={id}");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<AIMusicTrackResponse>>(jsonResponse);

                if (result.Any())
                    return result[0];

                return default;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                throw;
            }
        }

        public async Task<ChatCompletion> ComposeLyricAsync(string prompt, CancellationToken cancellationToken)
        {
            var messages = new List<ChatRequest>
                {
                    new ChatRequest { Role = "assistant", Content = $"Componha a letra de uma musica: {prompt} em portugues do brasil"}
                };

            var requestBody = new
            {
                model = "gpt-4o",
                messages,
            };

            var jsonPayload = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{_url}/chat/completions", content);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ChatCompletion>(responseData);
            return result;
        }
    }
}

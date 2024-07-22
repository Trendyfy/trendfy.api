using System.Text.Json.Serialization;

namespace PaymentProvider.Providers.Cora.Models
{
    public class CoraTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}

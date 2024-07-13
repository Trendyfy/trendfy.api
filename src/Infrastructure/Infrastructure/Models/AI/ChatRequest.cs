using Newtonsoft.Json;

namespace Infrastructure.Models.AI
{
    public class ChatRequest
    {
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}

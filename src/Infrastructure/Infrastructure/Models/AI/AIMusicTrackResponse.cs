using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.AI
{
    public class AIMusicTrackResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("lyric")]
        public string Lyric { get; set; }

        [JsonProperty("audio_url")]
        public string AudioUrl { get; set; }

        [JsonProperty("video_url")]
        public string VideoUrl { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("model_name")]
        public string ModelName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("gpt_description_prompt")]
        public string GptDescriptionPrompt { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}

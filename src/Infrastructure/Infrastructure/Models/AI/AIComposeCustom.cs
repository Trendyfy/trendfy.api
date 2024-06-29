using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MusicAssistentAI.Models.AI
{
    public class AIComposeCustom
    {
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("make_instrumental")]
        public bool MakeInstrumental { get; set; }

        [JsonProperty("wait_audio")]
        public bool WaitAudio { get; set; }
    }
}

using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MusicAssistentAI.Models.AI
{
    public class AIComposeSimple
    {
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("make_instrumental")]
        public bool MakeInstrumental { get; set; }

        [JsonProperty("wait_audio")]
        public bool WaitAudio { get; set; }
    }
}

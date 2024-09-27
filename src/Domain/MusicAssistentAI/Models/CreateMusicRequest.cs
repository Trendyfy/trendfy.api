using System.Text.Json.Serialization;

namespace MusicManager.Models
{
    public class CreateMusicRequest
    {
        public string Prompt { get; set; }
        public string Title { get; set; }
        public List<string> Genre { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Mood Mood { get; set; }
        public bool CustomMusic { get; set; }
        public bool MakeInstrumental { get; set; }
        public bool WaitAudio { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Mood
    {
        Joyful,
        Sad,
        Energetic,
        Calm,
        Romantic,
        Melancholic,
        Motivational,
        Hopeful,
        Happy,
        Relaxing,
        Danceable,
        Festive,
        Inspiring,
        Warm,
        Exciting,
    }
}

namespace MusicManager.Models
{
    public class CreateMusicRequest
    {
        public string Prompt { get; set; }
        public string Title { get; set; }
        public List<string> Genre { get; set; }
        public Mood Mood { get; set; }
        public bool CustomMusic { get; set; }
        public bool MakeInstrumental { get; set; }
        public bool WaitAudio { get; set; }
    }

    public enum Mood
    {
        Joyful,
        Sad,
        Energetic,
        Calm,
        Romantic,
        Melancholic,
        Motivational,
        Reflective,
        Tense,
        Hopeful,
        Aggressive,
        Serene,
        Dark,
        Happy,
        Relaxing,
        Danceable,
        Nostalgic,
        Festive,
        Inspiring,
        Warm,
        Exciting,
        Groovy,
        Spiritual,
        Mysterious,
        Tranquil
    }
}

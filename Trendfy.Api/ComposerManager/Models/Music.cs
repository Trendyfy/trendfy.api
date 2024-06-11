namespace ComposerManager.Models
{
    public class MusicModel
    {
        public Guid MusicId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public string Genre { get; set; }
        public string AudioUrl { get; set; }
        public DateTime UploadedAt { get; set; }
        public List<Like> Likes { get; set; }
    }
}

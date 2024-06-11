namespace ComposerManager.Models
{
    public class Like
    {
        public Guid LikeId { get; set; }
        public Guid UserId { get; set; } // Reference to the user who liked the composition
        public Guid CompositionId { get; set; } // Reference to the liked composition
        public DateTime LikedAt { get; set; }
    }
}

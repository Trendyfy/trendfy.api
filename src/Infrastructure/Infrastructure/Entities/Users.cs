using Google.Cloud.Firestore;

namespace Infrastructure.Entities
{
    [FirestoreData]
    public class User
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }

        [FirestoreProperty]
        public UserProfile ProfileType { get; set; }

        [FirestoreProperty]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum UserProfile
    {
        None,
        Composer,
        Musician,
        MusicProducer,
        ContentCreator
    }
}

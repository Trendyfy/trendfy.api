using Google.Cloud.Firestore;

namespace Infrastructure.Entities
{
    [FirestoreData]
    public class Transaction
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string UserId { get; set; }

        [FirestoreProperty]
        public long Amount { get; set; }

        [FirestoreProperty]
        public TransactionStatus Status { get; set; }
    }

    public enum TransactionStatus { 
       Pending,
       Canceled,
       Processed
    }
}

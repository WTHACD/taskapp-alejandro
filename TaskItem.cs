using Google.Cloud.Firestore;

namespace CloudTaskManager
{
    [FirestoreData]
    public class TaskItem
    {
        [FirestoreProperty]
        public string Id { get; set; } = string.Empty;

        [FirestoreProperty]
        public string Title { get; set; } = string.Empty;

        [FirestoreProperty]
        public bool IsComplete { get; set; } = false;

        [FirestoreProperty]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

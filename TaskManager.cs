using Google.Cloud.Firestore;

namespace CloudTaskManager
{
    public class TaskManager
    {
        private readonly FirestoreDb db;
        private readonly string collectionName = "tasks";

        public TaskManager(string projectId, string credentialsPath)
        {
            // Set environment variable for credentials
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsPath);

            // Initialize Firestore connection
            db = FirestoreDb.Create(projectId);
        }

        // CREATE: Add a new task
        public async Task AddTaskAsync(string title)
        {
            try
            {
                var task = new TaskItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = title,
                    IsComplete = false,
                    CreatedAt = DateTime.UtcNow
                };

                // Save to Firestore
                DocumentReference docRef = db.Collection(collectionName).Document(task.Id);
                await docRef.SetAsync(task);

                Console.WriteLine($"✓ Task added: {task.Title}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding task: {ex.Message}");
            }
        }

        // READ: Get all tasks
        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            try
            {
                var tasks = new List<TaskItem>();
                Query query = db.Collection(collectionName);
                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        var task = document.ConvertTo<TaskItem>();
                        tasks.Add(task);
                    }
                }

                return tasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting tasks: {ex.Message}");
                return new List<TaskItem>();
            }
        }

        // UPDATE: Mark a task as complete
        public async Task UpdateTaskAsync(string taskId)
        {
            try
            {
                DocumentReference docRef = db.Collection(collectionName).Document(taskId);

                // Check if document exists
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (!snapshot.Exists)
                {
                    Console.WriteLine("Task not found.");
                    return;
                }

                // Update IsComplete field
                await docRef.UpdateAsync("IsComplete", true);
                Console.WriteLine("✓ Task marked as complete");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating task: {ex.Message}");
            }
        }

        // DELETE: Delete a task
        public async Task DeleteTaskAsync(string taskId)
        {
            try
            {
                DocumentReference docRef = db.Collection(collectionName).Document(taskId);

                // Check if document exists
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (!snapshot.Exists)
                {
                    Console.WriteLine("Task not found.");
                    return;
                }

                await docRef.DeleteAsync();
                Console.WriteLine("✓ Task deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting task: {ex.Message}");
            }
        }

        // Helper method to display all tasks
        public async Task DisplayTasksAsync()
        {
            var tasks = await GetAllTasksAsync();

            if (tasks.Count == 0)
            {
                Console.WriteLine("\nNo tasks registered.");
                return;
            }

            Console.WriteLine("\n╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      TASK LIST                             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");

            int counter = 1;
            foreach (var task in tasks)
            {
                string status = task.IsComplete ? "[✓]" : "[ ]";
                Console.WriteLine($"\n{counter}. {status} {task.Title}");
                Console.WriteLine($"   ID: {task.Id}");
                Console.WriteLine($"   Created: {task.CreatedAt:MM/dd/yyyy hh:mm tt}");
                counter++;
            }
            Console.WriteLine();
        }
    }
}

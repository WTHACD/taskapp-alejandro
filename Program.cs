using CloudTaskManager;

Console.Clear();
Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
Console.WriteLine("║              CLOUD TASK MANAGER - FIRESTORE APP               ║");
Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
Console.WriteLine();

// Request Firebase configuration
Console.Write("Enter your Firebase Project ID: ");
string? projectId = Console.ReadLine();

Console.Write("Enter the full path to your credentials .json file: ");
string? credentialsPath = Console.ReadLine();

// Validate input data
if (string.IsNullOrWhiteSpace(projectId) || string.IsNullOrWhiteSpace(credentialsPath))
{
    Console.WriteLine("\n❌ You must provide both Project ID and credentials path.");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
    return;
}

// Verify credentials file exists
if (!File.Exists(credentialsPath))
{
    Console.WriteLine($"\n❌ Credentials file not found: {credentialsPath}");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
    return;
}

// Initialize task manager
TaskManager taskManager;
try
{
    taskManager = new TaskManager(projectId, credentialsPath);
    Console.WriteLine("\n✓ Successfully connected to Firebase Firestore");
}
catch (Exception ex)
{
    Console.WriteLine($"\n❌ Error connecting to Firebase: {ex.Message}");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
    return;
}

// Main menu loop
bool running = true;
while (running)
{
    Console.WriteLine("\n╔═════════════════════════════════════╗");
    Console.WriteLine("║            MAIN MENU                  ║");
    Console.WriteLine("╠═══════════════════════════════════════╣");
    Console.WriteLine("║  1. View Tasks                        ║");
    Console.WriteLine("║  2. Add Task                          ║");
    Console.WriteLine("║  3. Mark Task as Complete             ║");
    Console.WriteLine("║  4. Delete Task                       ║");
    Console.WriteLine("║  5. Exit                              ║");
    Console.WriteLine("╚═══════════════════════════════════════╝");
    Console.Write("\nSelect an option: ");

    string? option = Console.ReadLine();

    switch (option)
    {
        case "1":
            // Ver todas las tareas
            await taskManager.DisplayTasksAsync();
            break;

        case "2":
            // Add new task
            Console.Write("\nEnter the title for the new task: ");
            string? title = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(title))
            {
                await taskManager.AddTaskAsync(title);
            }
            else
            {
                Console.WriteLine("❌ Title cannot be empty.");
            }
            break;

        case "3":
            // Mark task as complete
            await taskManager.DisplayTasksAsync();
            Console.Write("\nEnter the task ID to mark as complete: ");
            string? updateId = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(updateId))
            {
                await taskManager.UpdateTaskAsync(updateId);
            }
            break;

        case "4":
            // Delete task
            await taskManager.DisplayTasksAsync();
            Console.Write("\nEnter the task ID to delete: ");
            string? deleteId = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(deleteId))
            {
                await taskManager.DeleteTaskAsync(deleteId);
            }
            break;

        case "5":
            // Exit
            Console.WriteLine("\nGoodbye! 👋");
            running = false;
            break;

        default:
            Console.WriteLine("\n❌ Invalid option. Please select 1-5.");
            break;
    }

    if (running)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

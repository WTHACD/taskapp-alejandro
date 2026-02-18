# 📋 Cloud Task Manager - Firestore Console App

## 🎯 Description

A C# console application that manages tasks (To-Do List) using Google Firestore as a cloud database.

## ✨ Features

- ✅ Create new tasks
- 📖 View all tasks
- ✔️ Mark tasks as complete
- 🗑️ Delete tasks
- ☁️ Cloud storage with Google Firestore

---

## 🚀 Google Firebase Setup

### Step 1: Create Firebase Project

1. Go to the [Firebase Console](https://console.firebase.google.com/)
2. Click **"Add project"**
3. Enter a name for your project (e.g., "CloudTaskManager")
4. Disable Google Analytics (optional for this project)
5. Click **"Create project"**

### Step 2: Enable Firestore Database

1. In the sidebar menu, find **"Firestore Database"** (under Build)
2. Click **"Create database"**
3. Select **"Start in production mode"**
4. Choose a location (recommended: `us-central`)
5. Click **"Enable"**

### Step 3: Generate Credentials (JSON File)

1. Go to **Project settings** (gear icon ⚙️ at the top)
2. Select the **"Service accounts"** tab
3. Click **"Generate new private key"**
4. Confirm by clicking **"Generate key"**
5. A JSON file will be downloaded (e.g., `cloudtaskmanager-abc123-firebase-adminsdk.json`)
6. **IMPORTANT:** Save this file in a secure location

### Step 4: Get the Project ID

1. On the same settings page, copy the **"Project ID"**
2. You'll need this when running the application

---

## 💻 Using the Application

### Running the Project

1. Open a terminal in the project folder:

   ```bash
   cd "e:\WACD\Documents\1Universidad\En-Feb 2026\CSE 310\New folder\CloudTaskManager"
   ```

2. Run the application:

   ```bash
   dotnet run
   ```

3. You will be prompted for:
   - **Firebase Project ID**: Paste the ID you copied in Step 4
   - **Credentials .json file path**: The full path where you saved the credentials file
     - Example: `C:\Users\YourUser\Downloads\cloudtaskmanager-firebase-adminsdk.json`
     - Or: `e:\WACD\firebase-credentials.json`

### Menu Options

```
1. View Tasks           - Shows all tasks with their status
2. Add Task             - Creates a new task
3. Mark as Complete     - Marks an existing task as complete
4. Delete Task          - Permanently deletes a task
5. Exit                 - Closes the application
```

---

## 📁 Project Structure

```
CloudTaskManager/
├── Program.cs           # Main menu and interface logic
├── TaskItem.cs          # Data model class
├── TaskManager.cs       # CRUD functions (Create, Read, Update, Delete)
├── CloudTaskManager.csproj
└── README.md            # This file
```

---

## 🔐 Security

⚠️ **IMPORTANT:**

- **NEVER** upload your credentials file (.json) to GitHub or public repositories
- Add `*.json` to your `.gitignore` file
- Credentials provide full access to your database

Example `.gitignore`:

```
# Firebase credentials
*.json
!CloudTaskManager.csproj

# Build folders
bin/
obj/
```

---

## 📦 Dependencies

- **.NET 8.0** or higher
- **Google.Cloud.Firestore** (installed automatically)

---

## 🎓 Concepts Learned

1. **Cloud service connections** (Google Firestore)
2. **CRUD operations** (Create, Read, Update, Delete)
3. **Asynchronous programming** with `async`/`await`
4. **Exception handling** with `try-catch`
5. **Service account authentication**
6. **Data models** with Firestore attributes

---

## 🐛 Troubleshooting

### Error: "Credentials file not found"

- Verify the path is correct and complete
- Use quotes if the path has spaces
- Example: `"C:\My Documents\firebase-key.json"`

### Error: "Error connecting to Firebase"

- Verify your Project ID is correct
- Confirm Firestore is enabled in the console
- Make sure you have an Internet connection

### Error: "Task not found"

- Copy the exact task ID (it's a long GUID)
- Use option 1 (View Tasks) to see available IDs

---

## 📝 Additional Notes

- Tasks are stored in a collection called `"tasks"` in Firestore
- Each task has a unique auto-generated ID (GUID)
- Creation date is recorded automatically
- You can view data in real-time in the Firebase console

---

## 👨‍💻 Author

Project for CSE 310 - Module #3 (Cloud Databases)

---

## 📚 Useful Resources

- [Firebase Documentation](https://firebase.google.com/docs)
- [Firestore for .NET](https://cloud.google.com/firestore/docs/quickstart-servers#c)
- [Firebase Console](https://console.firebase.google.com/)

# 📋 Cloud Task Manager

A C# console application that manages tasks using Google Firestore as a cloud database.

## ✨ Features

- ✅ Create new tasks
- 📖 View all tasks with completion status
- ✔️ Mark tasks as complete
- 🗑️ Delete tasks
- ☁️ Real-time cloud storage with Google Firestore

## 🛠️ Technologies

- **.NET 8.0**
- **Google Cloud Firestore**
- **C# Async/Await**

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK or higher
- Google Firebase account
- Firebase project with Firestore enabled
- Service account credentials (JSON file)

### Installation

1. Clone the repository
2. Install dependencies:
   ```bash
   dotnet restore
   ```

### Configuration

1. Create a Firebase project at [Firebase Console](https://console.firebase.google.com/)
2. Enable Firestore Database
3. Generate service account credentials (JSON file)
4. Run the application:
   ```bash
   dotnet run
   ```
5. Enter your Firebase Project ID and credentials file path when prompted

## 📦 Project Structure

- `Program.cs` - Main menu and application logic
- `TaskItem.cs` - Task data model
- `TaskManager.cs` - CRUD operations for Firestore

## 🔐 Security

⚠️ **Important:** Never commit your Firebase credentials file to version control. The `.gitignore` file is configured to exclude JSON credential files.

## 🎓 Learning Objectives

This project demonstrates:

- Cloud database integration
- CRUD operations with Firestore
- Asynchronous programming in C#
- Service account authentication
- Console application design

---

**CSE 310 - Module #3 (Cloud Databases)**

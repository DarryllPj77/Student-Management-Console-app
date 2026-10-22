# Student Management System

A simple C# console application for registering and managing students and their grades.

## Features

- Add students
- Prevent duplicate student IDs
- Retrieve all students
- Search for a student by ID
- Store student grades

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio 2026, Visual Studio Code, or another .NET-compatible IDE

## Run the application

From the repository root, run:

```powershell
dotnet restore .\StudentManagementSystem\StudentManagementSystem.csproj
dotnet run --project .\StudentManagementSystem\StudentManagementSystem.csproj
```

Alternatively, open `StudentManagementSystem.slnx` in Visual Studio and run the project.

## Project structure

```text
StudentManagementSystem/
├── Program.cs
├── Student.cs
├── Service/
│   └── StudentService.cs
└── StudentManagementSystem.csproj
```

## Notes

Student IDs must be unique. Attempting to register a student with an existing ID displays a duplicate-ID message.

# Student Management System

A terminal-based Student Management System developed using C# and .NET to practice and strengthen Object-Oriented Programming (OOP) principles through hands-on software development.

## Project Overview

This project is an ongoing learning initiative focused on designing a maintainable, object-oriented application without a graphical user interface or database.

The system is being developed incrementally, starting with fundamental OOP concepts and progressing toward more structured application architecture, input validation, and student record management.

## Features

**Currently Implemented:**

- Student registration and record retrieval
- Student grade management and average calculation
- Pass/fail evaluation
- Search students by ID
- Duplicate student ID prevention
- Student record reporting

**Planned Features:**

- Student record removal and updates
- Interactive console menu
- User input handling and validation
- Improved encapsulation and separation of responsibilities
- Additional OOP design improvements

## Learning Objectives

- Strengthen C# and .NET fundamentals
- Apply classes, objects, constructors, properties, and methods
- Practice encapsulation and access modifiers
- Manage collections of custom objects using `List<T>`
- Implement reusable methods and validation logic
- Develop maintainable, object-oriented code

## Development Status

**Work in Progress** — This project is actively being developed as part of a hands-on C# and .NET learning journey.

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

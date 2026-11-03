# Student Management System

A terminal-based Student Management System built with **C# and .NET 10**. The project is a hands-on learning exercise for Object-Oriented Programming, SOLID principles, encapsulation, validation, clean code, and incremental architecture refactoring.

## Project Overview

The application stores student records in memory and provides an interactive console menu for registration, searching, viewing, grading, updating, and removal. It has no database or graphical user interface, and data is not persisted between runs.

The console workflow has been separated from the application entry point. `Program.cs` creates the shared `StudentService` and starts `StudentConsoleUI`; the UI class owns terminal input, output, menu navigation, and operation workflows.

## Current Implemented Features

- Student registration through the terminal
- Unique positive student ID enforcement
- Search by student ID
- Display of all registered students
- Addition of three validated grades during each grade-entry operation
- Average calculation and pass/fail evaluation
- Student name and course updates
- Student removal with Y/N confirmation
- Menu redisplay and a “Press enter to continue” pause after operations
- Reusable console headers, input methods, and display methods
- Empty-collection and missing-student handling
- Registered-student count feedback after registration and removal
- Encapsulation through private setters and read-only collection exposure

## Current Validation Rules

| Input | Rule |
|---|---|
| Student ID | Must be a positive integer; IDs must be unique. |
| Student name | After trimming, must contain 2–70 characters. |
| Course | After trimming, must contain 3–120 characters. |
| Grade | Must be an integer from 70–100. |
| Passing average | Must be 75 or higher. |
| Empty collections | The application reports when no students are registered before operations that require a student. |

Reusable validation is implemented in `Validator/InputValidator.cs`. `StudentConsoleUI` reads and validates console input, `StudentService` prevents duplicate IDs, and `Student.AddGrade()` applies the grade rule before changing the grade collection.

## Current Architecture

| Component | Current responsibility |
|---|---|
| `Program` | Composition and startup: creates `StudentService` and starts the console UI. |
| `UI/StudentConsoleUI` | Menu loop, console navigation, prompts, validation flow, operation workflows, and terminal output. |
| `Service/StudentService` | In-memory student collection, registration, lookup, removal, count, and collection-state queries. |
| `Student` | Student identity and details, encapsulated grades, average calculation, pass/fail evaluation, and student-information updates. |
| `Validator/InputValidator` | Reusable student ID, required-text, and grade validation rules. |

The current UI methods are static and receive `StudentService` as a method parameter. Reviewing static versus instance methods and moving to constructor-based dependency injection is the next milestone; it is not described as implemented yet.

## OOP and Clean-Code Concepts Practiced

| Concept | Current application |
|---|---|
| Classes and objects | `Student`, `StudentService`, `StudentConsoleUI`, and `InputValidator` separate major responsibilities. |
| Constructors | `Student` is initialized with an ID, name, and course. |
| Encapsulation | Student setters are private, grade storage is private, and state changes go through methods. |
| Collections and generics | Students and grades are stored internally using `List<T>`. |
| Read-only interfaces | `IReadOnlyList<Student>` and `IReadOnlyList<int>` limit external collection mutation. |
| Nullable reference types | Student lookup returns `Student?` when a record may not exist. |
| Reusable methods | Input, display, collection, and validation behavior is expressed through named methods. |
| Separation of concerns | `Program.cs` no longer contains the interactive console workflow; UI, service, model, and validation concerns are separated. |

This project practices SOLID concepts progressively. It does **not** claim that all SOLID principles have been implemented.

## Encapsulation Improvements

- `Student.Name` and `Student.Course` use private setters.
- Grades are stored in the private `_grades` list and exposed through `IReadOnlyList<int>`.
- `StudentService._students` is private, and `GetAllStudents()` returns `IReadOnlyList<Student>` through `AsReadOnly()`.
- Grade changes go through `AddGrade()`.
- Student information changes go through `UpdateStudentInfo()`.

## Reusable Methods

`StudentConsoleUI.cs` currently contains console helpers and workflows including:

- `Header()` and `PauseConsole()`
- `ReadStudentID()`, `ReadRequiredText()`, and `ReadGrade()`
- `DisplayStudent()`, `ShowStudentDetails()`, and `DisplayStudentReport()`
- `CheckStudent()` and `DisplayMenu()`
- Registration, viewing, searching, grade entry, updating, and removal workflows

`StudentService.cs` currently contains:

- `AddStudent()`
- `GetAllStudents()`
- `GetStudentByID()`
- `RemoveStudent()`
- `HasRegisteredStudents()`
- `GetStudentCount()`

Exact, Git-verified refactoring examples are maintained in [SYNTAX_HISTORY.md](SYNTAX_HISTORY.md).

## Project Structure

```text
StudentManagementSystem/
├── AGENTS.md
├── README.md
├── ROADMAP.md
├── SYNTAX_HISTORY.md
├── StudentManagementSystem.slnx
└── StudentManagementSystem/
    ├── Program.cs
    ├── Student.cs
    ├── Service/
    │   └── StudentService.cs
    ├── UI/
    │   └── StudentConsoleUI.cs
    ├── Validator/
    │   └── InputValidator.cs
    └── StudentManagementSystem.csproj
```

## Application Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio 2026, Visual Studio Code, or another .NET-compatible IDE
- A terminal capable of running a .NET console application

## Running the Project

From the repository root:

```powershell
dotnet restore .\StudentManagementSystem\StudentManagementSystem.csproj
dotnet run --project .\StudentManagementSystem\StudentManagementSystem.csproj
```

Alternatively, open `StudentManagementSystem.slnx` in Visual Studio and run the project.

## Current Development Status

**Step 13.6 — Program.cs Refactoring is completed.**

The console workflow and reusable UI methods have been moved into `StudentConsoleUI`, and `Program.cs` now focuses on creating the service and starting the application. The current architecture remains an in-memory console application.

## Next Milestone

**Step 13.7 — Static vs. Instance Methods and Constructor-Based Dependency Injection**

This planned step will review the UI method design and how `StudentService` is supplied to `StudentConsoleUI`. It is not implemented yet. Later milestones remain documented in [ROADMAP.md](ROADMAP.md).

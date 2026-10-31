# Student Management System

A terminal-based Student Management System developed using **C# and .NET** to practice and strengthen Object-Oriented Programming (OOP) principles through hands-on software development.

## Project Overview

This project is an ongoing learning initiative focused on designing a maintainable, object-oriented application without a graphical user interface or database.

The system is developed incrementally, starting with fundamental OOP concepts and progressing toward structured application architecture, input validation, encapsulation, and student record management.

## Features

### Currently Implemented

- Student registration and record retrieval
- Student grade management and average calculation
- Pass/fail evaluation
- Search students by ID
- Duplicate student ID prevention
- Student record removal
- Student name and course updates
- Reusable student reporting methods
- Encapsulation using private setters and read-only collections
- Interactive menu-driven console workflow
- Terminal input for registration, searching, grades, updates, and removal
- Reusable validation for student IDs, names, courses, and grades
- Empty-list and missing-student handling

### Next Improvements

- Menu navigation improvements, confirmation prompts, and screen clearing
- Separation of console presentation from `Program.cs`
- Interfaces, dependency injection, and automated tests

## Step 11 — Encapsulation Improvements

This milestone focuses on protecting student information and collections from unintended modifications.

### 11.1 — Student Properties

**Previous Syntax:**

```csharp
public int StudentID { get; private set; } = 0;
public string Name { get; set; } = "";
public string Course { get; set; } = "";
```

**Updated Syntax:**

```csharp
public int StudentID { get; private set; } = 0;
public string Name { get; private set; } = "";
public string Course { get; private set; } = "";
```

**Changes:**
- Changed `Name` and `Course` setters from `public` to `private`.
- Prevented external classes from directly modifying student information.
- Student information must now be updated through `UpdateStudentInfo()`.

### 11.2 — Grades Collection

**Previous Syntax:**

```csharp
public List<int> Grades { get; private set; } = new List<int>();
```

**Updated Syntax:**

```csharp
private List<int> _grades = new List<int>();

public IReadOnlyList<int> Grades => _grades.AsReadOnly();
```

**Changes:**
- Introduced a private `_grades` collection.
- Exposed grades using `IReadOnlyList<int>`.
- Prevented external classes from directly adding or removing grades through the public property.
- Updated `AddGrade()` and `CalculateAverage()` to use `_grades`.

### 11.3 — Grade Initialization

**Previous Syntax:**

```csharp
Student student1 = new Student(1, "Darryll", "BSCS")
{
    Grades = { 90, 76, 87 }
};
```

**Updated Syntax:**

```csharp
Student student1 = new Student(1, "Darryll", "BSCS");

student1.AddGrade(90);
student1.AddGrade(76);
student1.AddGrade(87);
```

**Changes:**
- Removed direct collection initialization.
- Grades are now added through `AddGrade()`.
- Each grade is validated before being stored.

### 11.4 — StudentService Collection Encapsulation

**Previous Syntax:**

```csharp
private List<Student> _students = new List<Student>();

public List<Student> GetAllStudents()
{
    return _students;
}
```

**Updated Syntax:**

```csharp
private List<Student> _students = new List<Student>();

public IReadOnlyList<Student> GetAllStudents()
{
    return _students.AsReadOnly();
}
```

**Changes:**
- Changed the return type from `List<Student>` to `IReadOnlyList<Student>`.
- Prevented external classes from directly adding or removing students through the returned collection.
- Student registration and removal remain controlled through `StudentService` methods.

### 11.5 — Program.cs Collection Retrieval

**Previous Syntax:**

```csharp
List<Student> registeredStudents = studentService.GetAllStudents();
```

**Updated Syntax:**

```csharp
IReadOnlyList<Student> registeredStudents = studentService.GetAllStudents();
```

**Changes:**
- Updated the collection variable to match the service's read-only return type.
- Preserved student retrieval and iteration functionality.

### 11.6 — Student Report Method

**Previous Syntax:**

```csharp
static void DisplayStudentReport(List<Student> registeredStudents)
{
    foreach (var student in registeredStudents)
    {
        DisplayStudent(student);
    }
}
```

**Updated Syntax:**

```csharp
static void DisplayStudentReport(IReadOnlyList<Student> registeredStudents)
{
    foreach (var student in registeredStudents)
    {
        DisplayStudent(student);
    }
}
```

**Changes:**
- Updated the parameter type to `IReadOnlyList<Student>`.
- Maintained compatibility with the encapsulated student collection.
- Preserved the reusable reporting functionality.

## Step 12 — Interactive Console Workflow

The application now runs through a continuous terminal menu instead of predefined operations.

### Completed in Step 12.1–12.8

- Added a loop-based menu with `switch` routing and an explicit exit option.
- Added terminal registration for student ID, name, and course.
- Added interactive viewing, searching, grade entry, updating, and removal.
- Changed `StudentService.AddStudent()` to return a success result for duplicate-ID feedback.
- Added `StudentService.HasRegisteredStudents()` for empty-state checks.
- Added `InputValidator` for positive IDs, required text lengths, and the accepted grade range.
- Added retry loops for invalid numeric and text input.
- Verified the complete workflow through a scripted console smoke test.

### Remaining in Step 12.9

- Improve navigation with screen clearing and continue prompts.
- Add confirmation before destructive actions such as student removal.

## OOP Concepts Implemented

| Concept | Implementation |
|---|---|
| Classes and Objects | `Student` and `StudentService` |
| Constructors | Student initialization |
| Properties | Student ID, name, course, and grades |
| Encapsulation | Private setters and controlled methods |
| Access Modifiers | `public` and `private` |
| Collections | `List<int>` and `List<Student>` |
| Read-Only Interfaces | `IReadOnlyList<int>` and `IReadOnlyList<Student>` |
| Methods | Registration, searching, updating, removal, and grade calculations |
| Nullable Reference Types | `Student?` |
| Validation | Duplicate IDs, grade ranges, and student information |
| Object References | Shared student objects across application components |

## Development Progress

| Step | Milestone | Status |
|---|---|---|
| 1–3 | Student class, properties, constructors, and object instantiation | Completed |
| 4 | Grade management and evaluation | Completed |
| 5 | Student methods integration | Completed |
| 6 | StudentService implementation | Completed |
| 7 | Search students by ID | Completed |
| 8 | Duplicate student ID prevention | Completed |
| 9 | Student removal | Completed |
| 10 | Student information updates | Completed |
| 11 | Encapsulation and read-only collections | Completed |
| 12.1–12.8 | Interactive console operations and validation | Completed |
| 12.9 | Menu navigation and confirmation improvements | Next |

## Development Status

**Work in Progress — Step 12.1–12.8 Completed**

The application now starts with an empty in-memory `StudentService` and accepts student operations through the terminal menu.

The next milestone is **Step 12.9 — Menu Improvements**, followed by the Phase 4 refactor that moves console presentation out of `Program.cs`.

Student data is currently stored in memory and is not persisted between application runs.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio 2026, Visual Studio Code, or another .NET-compatible IDE

## Run the Application

From the repository root:

```powershell
dotnet restore .\StudentManagementSystem\StudentManagementSystem.csproj
dotnet run --project .\StudentManagementSystem\StudentManagementSystem.csproj
```

Alternatively, open `StudentManagementSystem.slnx` in Visual Studio.

## Project Structure

```text
StudentManagementSystem/
├── Program.cs
├── Student.cs
├── Service/
│   └── StudentService.cs
├── Validator/
│   └── InputValidator.cs
└── StudentManagementSystem.csproj
```

## Learning Objectives

- Strengthen C# and .NET fundamentals
- Apply OOP principles through practical development
- Understand classes, constructors, properties, and methods
- Practice encapsulation and access modifiers
- Manage collections using `List<T>` and `IReadOnlyList<T>`
- Implement reusable methods and validation
- Improve software architecture and code maintainability

## Future Development

The project will continue evolving through interactive console operations, stronger validation, improved separation of responsibilities, and additional object-oriented design practices.

## Development Roadmap

This project follows a structured, milestone-based learning roadmap focused on C# fundamentals, Object-Oriented Programming, clean architecture, and software testing.

See [ROADMAP.md](ROADMAP.md) for the complete development plan and progress.

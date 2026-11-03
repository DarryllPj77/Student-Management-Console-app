# Student Management System — Development Roadmap

**Project:** C# / .NET 10 Console Application

**Focus:** Object-Oriented Programming, Encapsulation, SOLID Principles, and Clean Code

**Current milestone:** Step 13.6 — Program.cs Refactoring (Completed)

**Next milestone:** Step 13.7 — Static vs. Instance Methods and Constructor-Based Dependency Injection

This project is being developed gradually to build a terminal-based Student Management System while applying OOP principles and clean-code practices. Completed milestones describe the current source; future milestones are plans and are not implemented yet.

---

## Phase 1 — OOP Fundamentals

### Completed

| Step | Implementation | Status |
|---|---|---|
| 1 | Create the `Student` class and properties | Completed |
| 2 | Implement a parameterized constructor | Completed |
| 3 | Instantiate and display `Student` objects | Completed |
| 4 | Implement `AddGrade()`, `CalculateAverage()`, and `IsPassed()` | Completed |
| 5 | Integrate student methods in `Program.cs` | Completed |

**Concepts practiced:** Classes, objects, constructors, properties, methods, return types, and object references.

---

## Phase 2 — Student Management Operations

### Completed

| Step | Implementation | Status |
|---|---|---|
| 6 | Create `StudentService` and manage student collections | Completed |
| 7 | Search students by ID | Completed |
| 8 | Prevent duplicate student IDs | Completed |
| 9 | Remove registered students | Completed |
| 10 | Update student information | Completed |
| 11 | Improve encapsulation with private setters and `IReadOnlyList<T>` | Completed |

**Concepts practiced:** Encapsulation, access modifiers, `List<T>`, `IReadOnlyList<T>`, nullable references, and validation.

---

## Phase 3 — Interactive Console Application

### Completed: Steps 12.1–12.9.5

| Step | Implementation | Status |
|---|---|---|
| 12.1 | Implement `DisplayMenu()`, loops, and `switch` statements | Completed |
| 12.2 | Accept student ID, name, and course from the terminal | Completed |
| 12.3 | Display all registered students | Completed |
| 12.4 | Search using a user-provided ID | Completed |
| 12.5 | Select a student and enter grades | Completed |
| 12.6 | Update name and course using an ID | Completed |
| 12.7 | Remove a student using an ID | Completed |
| 12.8.1 | Review repeated student ID input loops | Completed |
| 12.8.2 | Extract `ReadStudentID()` | Completed |
| 12.8.3 | Review repeated name and course input loops | Completed |
| 12.8.4 | Extract `ReadRequiredText()` | Completed |
| 12.8.5 | Review repeated grade input loops | Completed |
| 12.8.6 | Extract `ReadGrade()` | Completed |
| 12.8.7 | Review direct student-property display parameters | Completed |
| 12.8.8 | Extract `ShowStudentDetails(Student student)` | Completed |
| 12.8.9 | Review repeated empty-collection checks | Completed |
| 12.8.10 | Add `HasRegisteredStudents()` | Completed |
| 12.8.11 | Review direct validation conditions | Completed |
| 12.8.12 | Add `InputValidator.ValidateStudentID()` | Completed |
| 12.8.13 | Add `InputValidator.ValidateRequiredText()` | Completed |
| 12.8.14 | Add `InputValidator.ValidateGrade()` | Completed |
| 12.8.15 | Use `IReadOnlyList<T>` for exposed collections | Completed |
| 12.8.16 | Apply reusable methods through the interactive operations | Completed |
| 12.8.17 | Review the reusable-method refactoring | Completed |
| 12.9.1 | Display the menu after each operation | Completed |
| 12.9.2 | Add a “Press Enter to continue” pause | Completed |
| 12.9.3 | Improve console headers and spacing | Completed |
| 12.9.4 | Add removal confirmation | Completed |
| 12.9.5 | Test the complete interactive workflow | Completed |

**Current console workflow:** The menu loops until exit, operation methods return to the menu, `PauseConsole()` pauses between completed operations, `Header()` formats sections, and removal requires Y/N confirmation.

**Current reusable methods:**

- `UI/StudentConsoleUI.cs`: console input, headers, pauses, student displays, menu navigation, and student-operation workflows
- `Service/StudentService.cs`: collection access, registration, lookup, removal, count, and collection-state queries
- `Validator/InputValidator.cs`: student ID, required-text, and grade validation

---

## Phase 4 — Clean Code and Architecture

### Completed: Steps 13.1–13.6

| Step | Implementation | OOP / Clean Code Focus | Status |
|---|---|---|---|
| 13.1 | Review the responsibilities accumulated in `Program.cs` | Identify mixed startup and presentation concerns | Completed |
| 13.2 | Create the `UI` folder and `StudentConsoleUI` class | Introduce a dedicated console presentation component | Completed |
| 13.3 | Move reusable input and display methods to `StudentConsoleUI` | Group terminal-specific behavior | Completed |
| 13.4 | Move the menu loop and navigation to `StudentConsoleUI` | Separate console control flow from startup | Completed |
| 13.5 | Move student-operation workflows to `StudentConsoleUI` | Keep interactive workflows with the UI layer | Completed |
| 13.6 | Refactor `Program.cs` to compose and start the application | Reduce the entry point to startup responsibilities | Completed |
| 13.7 | Static vs. Instance Methods and Constructor-Based Dependency Injection | Review method ownership and inject `StudentService` through construction | **Next** |
| 14 | Continue refining `StudentConsoleUI` responsibilities | Single Responsibility Principle | Planned |
| 15 | Improve validation and error handling | Reliable business rules | Planned |
| 16 | Introduce interfaces | Create an `IStudentService` abstraction | Planned |
| 17 | Apply dependency inversion through the service abstraction | Dependency Inversion Principle | Planned |
| 18 | Refactor methods and responsibilities | SOLID principles | Planned |

### Verified Step 13.6 Architecture

- `Program.cs` creates one `StudentService` instance.
- `Program.cs` starts the application through `StudentConsoleUI.DisplayMenu(studentService)`.
- `StudentConsoleUI` contains the menu loop, console helpers, displays, and interactive student operations.
- `StudentService` continues to own the in-memory student collection operations.
- `Student` continues to own student state, grade behavior, and student-information updates.
- `InputValidator` continues to own reusable validation rules.

Step 13.7 remains pending. The current UI methods are static and accept `StudentService` parameters; constructor-based dependency injection is not yet documented as completed.

**Expected result of Phase 4:** Cleaner responsibilities and reduced coupling between components. The project does not claim that all SOLID principles are implemented before these milestones are completed.

---

## Phase 5 — Advanced OOP Practice

| Step | Implementation | OOP Focus | Status |
|---|---|---|---|
| 19 | Introduce `Student` and `GraduateStudent` types | Inheritance | Planned |
| 20 | Implement different student evaluation rules | Polymorphism | Planned |
| 21 | Introduce abstract classes where appropriate | Abstraction | Planned |
| 22 | Implement grade notifications | Delegates and events | Planned |
| 23 | Introduce enumerations | Strongly typed statuses | Planned |
| 24 | Refactor using interfaces and composition | Flexible OOP design | Planned |

Inheritance and abstract classes will only be introduced when they solve a meaningful problem instead of being forced into the project.

---

## Phase 6 — Testing and Final Improvements

| Step | Implementation | Goal | Status |
|---|---|---|---|
| 25 | Create a test project | Introduce unit testing | Planned |
| 26 | Test `Student` methods | Verify grade calculations and validation | Planned |
| 27 | Test `StudentService` | Verify registration, search, and removal | Planned |
| 28 | Test edge cases | Handle invalid input and empty collections | Planned |
| 29 | Final code refactoring | Improve readability and maintainability | Planned |
| 30 | Update README and GitHub repository | Document the completed project | Planned |

---

## Current Project Structure

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

## Target Architecture Direction

The next architectural change is intentionally limited to Step 13.7: review static versus instance UI methods and introduce constructor-based dependency injection. Interfaces, broader dependency inversion, advanced OOP, and unit testing remain future work.

---

## Development Progress Tracker

Through Step 13.6, **46 of 64 tracked milestones are completed**: 5 in Phase 1, 6 in Phase 2, 29 in Phase 3, and 6 in Phase 4. Step 13.7 is next.

| Phase | Progress |
|---|---:|
| Phase 1 — OOP Fundamentals | 5 / 5 |
| Phase 2 — Student Management Operations | 6 / 6 |
| Phase 3 — Interactive Console | 29 / 29 |
| Phase 4 — Clean Code and Architecture | 6 / 12 |
| Phase 5 — Advanced OOP Practice | 0 / 6 |
| Phase 6 — Testing and Final Improvements | 0 / 6 |

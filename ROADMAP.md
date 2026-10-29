# Student Management System — Development Roadmap

**Project:** C# / .NET Console Application  
**Focus:** Object-Oriented Programming, Encapsulation, SOLID Principles, and Clean Code  
**Current Progress:** Step 11 completed — Step 12 next

This project is being developed gradually to build a complete terminal-based Student Management System while applying OOP principles and clean architecture.

---

## Phase 1 — OOP Fundamentals

### Completed

| Step | Implementation | Status |
|---|---|---|
| 1 | Create `Student` class and properties | Completed |
| 2 | Implement parameterized constructors | Completed |
| 3 | Instantiate and display `Student` objects | Completed |
| 4 | Implement `AddGrade()`, `CalculateAverage()`, and `IsPassed()` | Completed |
| 5 | Integrate student methods in `Program.cs` | Completed |

**Concepts:** Classes, objects, constructors, properties, methods, return types, and object references.

---

## Phase 2 — Student Management Operations

### Completed

| Step | Implementation | Status |
|---|---|---|
| 6 | Create `StudentService` and manage collections | Completed |
| 7 | Search students by ID | Completed |
| 8 | Prevent duplicate student IDs | Completed |
| 9 | Remove registered students | Completed |
| 10 | Update student information | Completed |
| 11 | Improve encapsulation with private setters and `IReadOnlyList` | Completed |

**Concepts:** Encapsulation, access modifiers, `List<T>`, `IReadOnlyList<T>`, nullable references, and validation.

---

## Phase 3 — Interactive Console Application

### Next Phase

| Step | Implementation | Description |
|---|---|---|
| 12.1 | Console menu | Implement `DisplayMenu()`, loops, and `switch` statements |
| 12.2 | Register student | Accept ID, name, and course from the terminal |
| 12.3 | View students | Display all registered students |
| 12.4 | Search student | Search using a user-provided ID |
| 12.5 | Add grade | Select a student and enter a grade |
| 12.6 | Update student | Update name and course using an ID |
| 12.7 | Remove student | Remove a student using an ID |
| 12.8 | Input validation | Handle invalid input using `TryParse()` |
| 12.9 | Menu improvements | Add screen clearing, navigation, and confirmation prompts |

**Expected result:** A fully interactive terminal application without hardcoded student operations.

---

## Phase 4 — Clean Code and Architecture

| Step | Implementation | OOP Focus |
|---|---|---|
| 13 | Refactor `Program.cs` | Separate application logic from presentation |
| 14 | Introduce `StudentConsoleUI` | Single Responsibility Principle |
| 15 | Improve validation and error handling | Reliable business rules |
| 16 | Introduce interfaces | Create `IStudentService` abstraction |
| 17 | Apply manual dependency injection | Dependency Inversion Principle |
| 18 | Refactor methods and responsibilities | SOLID principles |

**Expected result:** Cleaner responsibilities and reduced coupling between components.

---

## Phase 5 — Advanced OOP Practice

| Step | Implementation | OOP Focus |
|---|---|---|
| 19 | Introduce `Student` and `GraduateStudent` types | Inheritance |
| 20 | Implement different student evaluation rules | Polymorphism |
| 21 | Introduce abstract classes where appropriate | Abstraction |
| 22 | Implement grade notifications | Delegates and events |
| 23 | Introduce enumerations | Strongly typed statuses |
| 24 | Refactor using interfaces and composition | Flexible OOP design |

Inheritance and abstract classes will only be introduced when they solve a meaningful problem instead of being forced into the project.

---

## Phase 6 — Testing and Final Improvements

| Step | Implementation | Goal |
|---|---|---|
| 25 | Create a test project | Introduce unit testing |
| 26 | Test `Student` methods | Verify grade calculations and validation |
| 27 | Test `StudentService` | Verify registration, search, and removal |
| 28 | Test edge cases | Handle invalid input and empty collections |
| 29 | Final code refactoring | Improve readability and maintainability |
| 30 | Update README and GitHub repository | Document the completed project |

---

## Target Project Architecture

```text
StudentManagementSystem/
├── Models/
│   ├── Student.cs
│   └── GraduateStudent.cs
├── Services/
│   └── StudentService.cs
├── Interfaces/
│   └── IStudentService.cs
├── UI/
│   └── StudentConsoleUI.cs
└── Program.cs
```

The project structure will grow gradually. Files will only be introduced when they are required by the relevant development step.

---

## Recommended Repository Organization

```text
StudentManagementSystem/
├── README.md
├── ROADMAP.md
├── StudentManagementSystem.slnx
└── StudentManagementSystem/
	├── Program.cs
	├── Student.cs
	├── Service/
	│   └── StudentService.cs
	└── StudentManagementSystem.csproj
```

---

## Development Progress Tracker

**Overall Progress:** 11 / 38 milestones

| Phase | Progress |
|---|---:|
| Phase 1 — OOP Fundamentals | 5 / 5 |
| Phase 2 — Student Management | 6 / 6 |
| Phase 3 — Interactive Console | 0 / 9 |
| Phase 4 — Clean Code and Architecture | 0 / 6 |
| Phase 5 — Advanced OOP Practice | 0 / 6 |
| Phase 6 — Testing and Final Improvements | 0 / 6 |

---


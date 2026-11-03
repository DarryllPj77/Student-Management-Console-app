# Student Management System — Syntax History

This file records meaningful refactoring changes using source verified from Git history. Unless an entry says otherwise, **Previous Syntax** is taken from commit `d40bc9e` (`feat: add interactive student management workflow`), and **Updated Syntax** is taken from the current working tree.

No illustrative or reconstructed historical code is used.

---

## 1. Application Startup Calls the Dedicated Console UI

### Previous Syntax

```csharp
DisplayMenu(studentService);
```

### Updated Syntax

```csharp
StudentConsoleUI.DisplayMenu(studentService);
```

### What Changed

`Main()` no longer calls a menu method declared inside `Program`. It calls the menu through the new `StudentConsoleUI` class.

### Why It Changed

The application entry point now focuses on creating the service and starting the UI instead of owning the terminal workflow.

---

## 2. Menu Navigation Moved Out of `Program.cs`

### Previous Syntax

```csharp
static void DisplayMenu(StudentService studentService)
```

### Updated Syntax

```csharp
public static void DisplayMenu(StudentService studentService)
```

### What Changed

The menu loop and its operation dispatch moved from `Program` to `StudentConsoleUI`. The method became `public` so `Program.Main()` can start it through the UI class.

### Why It Changed

Menu rendering and console navigation are presentation responsibilities. Keeping them in the UI component reduces the responsibilities held by `Program`.

---

## 3. Reusable Student ID Input Moved to the UI Component

### Previous Syntax

```csharp
static int ReadStudentID()
{
    while (true)
    {
        Console.Write("Enter student id: ");
        if (int.TryParse(Console.ReadLine(), out int id) && InputValidator.ValidateStudentID(id))
        {
            return id;
        }
        else
        {
            Console.WriteLine("Invalid Student ID! Please enter a positive number.");
        }
    }
}
```

### Updated Syntax

```csharp
public static int ReadStudentID()
{
    while (true)
    {
        Console.Write("Enter student id: ");
        if (int.TryParse(Console.ReadLine(), out int id) && InputValidator.ValidateStudentID(id))
        {
            return id;
        }
        else
        {
            Console.WriteLine("Invalid Student ID! Please enter a positive number.");
        }
    }
}
```

### What Changed

The method moved from `Program.cs` to `UI/StudentConsoleUI.cs` and became publicly accessible on the UI class. Its input loop and validation behavior were preserved.

### Why It Changed

Reading terminal input belongs with the console presentation workflow rather than the application entry point.

---

## 4. `Program.cs` Was Reduced to Composition and Startup

### Previous Syntax

```csharp
#region -- Display Outputs --
DisplayMenu(studentService);

//DisplayStudentReport(registeredStudents);

//CheckingStudentById(studentService, 2); // Check student if existing by ID

//RemoveStudentById(studentService, 5); // Remove student by ID
//DisplayStudentReport(registeredStudents); // Display Student Report

//UpdateStudentInformation(student1, "Darryll J Pajaganas", "BSIT");

//DisplayStudentReport(registeredStudents); // checking if the student 1 updated

//student1.Name = "New Name";
#endregion
```

### Updated Syntax

```csharp
#region -- Display Outputs --
StudentConsoleUI.DisplayMenu(studentService);

#endregion
```

### What Changed

Active UI execution now delegates to `StudentConsoleUI`, and the menu, input, display, and operation methods are no longer declared in `Program.cs`. Existing earlier learning examples in the upper regions of `Main()` remain preserved as comments.

### Why It Changed

`Program.cs` now acts as the composition root and startup point, while terminal-specific responsibilities live in the UI component.

---

## 5. Collection-State Check Was Simplified

### Previous Syntax

```csharp
public bool HasRegisteredStudents()
{
    if(_students.Count > 0)
    {
        return true;
    }
    return false;
}
```

### Updated Syntax

```csharp
public bool HasRegisteredStudents()
{
    return _students.Count > 0;
}
```

### What Changed

The explicit `if` and two Boolean returns were replaced by returning the comparison result directly. The earlier form remains preserved as commented-out learning code in the current source.

### Why It Changed

The direct return expresses the same rule with less control-flow noise while retaining the method’s intention-revealing name.

---

## 6. Pass/Fail Evaluation No Longer Prints From the No-Grade Branch

### Previous Syntax

```csharp
public bool IsPassed()
{
    double calculatedAverage = CalculateAverage();

    if(_grades.Count == 0)
    {
        Console.WriteLine("No grades, Not pass!");
        return false;
    }

    return CalculateAverage() >= 75;
}
```

### Updated Syntax

```csharp
public bool IsPassed()
{
    double calculatedAverage = CalculateAverage();

    if(_grades.Count == 0)
    {
        return false;
    }

    if(calculatedAverage >= 70 && calculatedAverage < 75)
    {
        return false;
    }

    return CalculateAverage() >= 75;
}
```

### What Changed

The no-grade branch now returns a result without writing to the console, and the 70–74 range is represented by an explicit failing branch before the final passing comparison.

### Why It Changed

Pass/fail evaluation stays focused on returning a Boolean result. Console presentation remains the responsibility of the UI layer.

---

## 7. Mutable Collections Were Replaced by Read-Only Exposure

This previous syntax is verified from commit `e03e005` (`feat: implement student management operations and OOP encapsulation`).

### Previous Syntax

```csharp
public List<int> Grades { get; private set; } = new List<int>();

public List<Student> GetAllStudents()
{
    return _students;
}
```

### Updated Syntax

```csharp
private List<int> _grades = new List<int>();
public IReadOnlyList<int> Grades => _grades.AsReadOnly();

public IReadOnlyList<Student> GetAllStudents()
{
    return _students.AsReadOnly();
}
```

### What Changed

The grade collection moved behind a private field, and both exposed collection APIs now return `IReadOnlyList<T>` views instead of mutable `List<T>` objects.

### Why It Changed

Callers can inspect grades and students without receiving a mutable list that could bypass the classes responsible for controlling those collections.

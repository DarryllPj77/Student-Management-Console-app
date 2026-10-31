using StudentManagementSystem.Service;
using StudentManagementSystem.Validator;

namespace StudentManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region -- Object Instantiation -- 
            Student student1 = new Student(1, "Darryll", "BSCS");
            Student student2 = new Student(2, "Beji", "BSIT");
            Student student3 = new Student(1, "Celeine", "BSCE");

            #endregion

            #region -- AddGrade() Method --
            // Using AddGrade() fot students
            //student1.AddGrade(90);
            //student1.AddGrade(76);
            //student1.AddGrade(87);

            //student2.AddGrade(76);
            //student2.AddGrade(76);
            //student2.AddGrade(76);

            //student3.AddGrade(98);
            //student3.AddGrade(94);
            //student3.AddGrade(96);
            #endregion


            #region -- Application Manager --
            StudentService studentService = new StudentService();
            #endregion

            #region -- Registration of Students --
            // Using StudentService for Registration -- Manual
            //studentService.AddStudent(student1);
            //studentService.AddStudent(student2);
            //studentService.AddStudent(student3);
            #endregion

            #region -- Operations / Data Retrieval
            // retrieve the students 
            IReadOnlyList<Student> registeredStudents = studentService.GetAllStudents(); // updated for encapsulation 
            #endregion

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
        }




        #region -- Functions used for switch --
        static void DisplayMenu(StudentService studentService)
        {
            while (true)
            {
                Header("STUDENT MANAGEMENT SYSTEM");

                Console.WriteLine("[1] Register Student");
                Console.WriteLine("[2] View All Students");
                Console.WriteLine("[3] Search Student by ID");
                Console.WriteLine("[4] Add Student Grade");
                Console.WriteLine("[5] Updated Student Information");
                Console.WriteLine("[6] Remove Student");
                Console.WriteLine("[0] Exit");
                Console.Write("\nSelect an option (0-6): ");
                if(!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Please enter valid number.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Executing Option 1...");
                        RegisteredStudent(studentService);
                        break;
                    case 2:
                        Console.WriteLine("Executing Option 2...");
                        ViewAllStudents(studentService);
                        break;
                    case 3:
                        Console.WriteLine("Executing Option 3...");
                        SearchStudentById(studentService);
                        break;
                    case 4:
                        Console.WriteLine("Executing Option 4...");
                        AddStudentGrade(studentService);
                        break;
                    case 5:
                        Console.WriteLine("Executing Option 5...");
                        UpdateStudentInformation(studentService);
                        break;
                    case 6:
                        Console.WriteLine("Executing Option 6...");
                        RemoveStudentByID(studentService);
                        break;
                    case 0:
                        Console.WriteLine("Exiting program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please choose between 0 and 6.");
                        break;
                }
            }
        }

        static void RegisteredStudent(StudentService studentService)
        {
            Header("REGISTERED STUDENT");

            int id = ReadStudentID();
            string name = "";
            string course = "";

            while (true)
            {
                Console.Write("Enter Student name: ");
                name = Console.ReadLine() ?? "";
                if (InputValidator.ValidateRequiredText(name, "nametype"))
                {
                    name = name.Trim();
                    break;
                }
                Console.WriteLine("Error: Name must be between 2 and 70 characters long. Try again.\n");
            }

            while (true)
            {
                Console.Write("Enter your Course: ");
                course = Console.ReadLine() ?? "";
                if (InputValidator.ValidateRequiredText(course, "coursetype"))
                {
                    course = course.Trim();
                    break;
                }
                Console.WriteLine("Error: Course must be between 3 and 120 characters long. Try again.\n");
            }

            Student student = new Student(id, name, course);
            bool isRegistered = studentService.AddStudent(student);

            if (isRegistered)
            {
                Console.WriteLine($"\nRegistration successful for {name} in {course} with ID #{id}!");
            }
            else
            {
                Console.WriteLine($"Registration failed! Student ID {id} already exists.");
            }
        }

        static void ViewAllStudents(StudentService studentService)
        {
            IReadOnlyList<Student> retrieveStudents = studentService.GetAllStudents(); //Retrieve Students

            Header("ALL REGISTERED STUDENT"); ;

            if (retrieveStudents.Count == 0)
            {
                Console.WriteLine("No registered students found!");
                return;
            }

            DisplayStudentReport(retrieveStudents);
        }

        static void SearchStudentById(StudentService studentService)
        {

            Header("SEARCH STUDENT BY ID");

            int id = ReadStudentID();

            Student? student = studentService.GetStudentByID(id);
            if (student != null)
            {
                DisplayStudent(student);
            }
            else
            {
                Console.WriteLine("Student not found!");
                return;
            }
        }
        static void AddStudentGrade(StudentService studentService)
        {
            Header("ADD STUDENT GRADE");

            IReadOnlyList<Student> retrieveStudents = studentService.GetAllStudents(); //Retrieve Students
            if (retrieveStudents.Count == 0)
            {
                Console.WriteLine("No students registered yet!");
                return;
            }

            while (true)
            {
                int id = ReadStudentID(); // For ID input

                Student? student = studentService.GetStudentByID(id);

                if(student == null)
                {
                    Console.WriteLine("Student not found!");
                    continue;
                }
                while (true)
                {
                    Console.Write("Enter grade (70 - 100): ");
                    if(int.TryParse(Console.ReadLine(), out int grade) && InputValidator.ValidateGrade(grade))
                    {
                        student.AddGrade(grade);
                        return;
                    }
                    Console.WriteLine("Invalid grade! Enter a number from 70 to 100.");
                }
            }
        }

        static void UpdateStudentInformation(StudentService studentService)
        {
            string name = "";
            string course = "";


            Header("UPDATE STUDENT INFORMATION");
            if (!studentService.HasRegisteredStudents())
            {
                Console.WriteLine("No student's registered yet!");
                return;
            }

            while (true)
            {
                int id = ReadStudentID();

                Student? student = studentService.GetStudentByID(id);
                if (student != null)
                {
                    Console.WriteLine("Current Student Information:");
                    Console.WriteLine($"Student ID: {id}");
                    Console.WriteLine($"Current Name: {student.Name}");
                    Console.WriteLine($"Current Course: {student.Course}");
                }
                else
                {
                    Console.WriteLine("Student not found!");
                    continue;
                }

                while (true)
                {
                    Console.Write("Enter Student name: ");
                    name = Console.ReadLine() ?? "";
                    if (InputValidator.ValidateRequiredText(name, "nametype"))
                    {
                        name = name.Trim();
                        break;
                    }
                    Console.WriteLine("Error: Name must be between 2 and 70 characters long. Try again.\n");
                }

                while (true)
                {
                    Console.Write("Enter your Course: ");
                    course = Console.ReadLine() ?? "";
                    if (InputValidator.ValidateRequiredText(course, "coursetype"))
                    {
                        course = course.Trim();
                        break;
                    }
                    Console.WriteLine("Error: Course must be between 3 and 120 characters long. Try again.\n");
                }
                student.UpdateStudentInfo(name, course);
                return;
            }

        }

        static void RemoveStudentByID(StudentService studentService)
        {
            Header("REMOVE STUDENT");

            if (!studentService.HasRegisteredStudents()) // since HasRegisteredStudents() returns true if empty, using reverse
            {                                            // making it Has not registered Student
                Console.WriteLine("No student's registered yet!");
                return;
            }

            while (true)
            {
                int id = ReadStudentID();

                bool isRemoved = studentService.RemoveStudent(id); // remove student
                if (isRemoved)
                {
                    Console.WriteLine($"Student ID {id} removed successfully!");
                    return; // if returns automatic go backs to main menu
                }
                else
                {
                    Console.WriteLine("Student not found!");
                }
            }
        }

        #endregion

        #region -- Functions used before --
        static void DisplayStudent(Student student)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("STUDENT GRADE REPORT");
            Console.WriteLine("=========================");

            Console.WriteLine(student.StudentID);
            Console.WriteLine(student.Name);
            Console.WriteLine(student.Course);

            double average = student.CalculateAverage();
            bool isPassed = student.IsPassed();

            Console.WriteLine($"Average: {average:F2}");
            Console.WriteLine($"Status: {(isPassed ? "PASSED" : "FAILED")}");

        }

        static void DisplayStudentReport(IReadOnlyList<Student>  registeredStudents)
        {
        // Function fo displaying Student report
            foreach (var student in registeredStudents)
            {
                DisplayStudent(student);
            }
        }

        static void CheckingStudentById(StudentService studentService, int studentId)
        {
            Console.WriteLine("================================");
            Console.WriteLine("Checking student by Id");
            Console.WriteLine("================================");
            Student? student = studentService.GetStudentByID(studentId);

            if (student != null)
            {
                DisplayStudent(student);
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void RemoveStudentById(StudentService studentService, int studentID)
        {
            Console.WriteLine("================================");
            Console.WriteLine("Remove student by Id");
            Console.WriteLine("================================");

            int idToRemove = studentID;

            bool isStudentRemoved = studentService.RemoveStudent(idToRemove);

            Console.WriteLine($"Removing Student ID:{idToRemove}");

            if (isStudentRemoved)
            {
                Console.WriteLine("Student remove successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void UpdateStudentInformation(Student student, string name,  string course)
        {
            Console.WriteLine("================================");
            Console.WriteLine("Updated Student Information");
            Console.WriteLine("================================");

            student.UpdateStudentInfo(name, course);
            
        }

        #endregion


        #region -- Reusable Methods --

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

        #endregion

        #region -- Header Function for UI --
        static void Header(string headerName)
        {
            Console.WriteLine("===================================");
            Console.WriteLine(headerName);
            Console.WriteLine("===================================");
        }
        #endregion
    }
}

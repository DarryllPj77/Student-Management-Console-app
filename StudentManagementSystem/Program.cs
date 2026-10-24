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
            student1.AddGrade(90);
            student1.AddGrade(76);
            student1.AddGrade(87);

            student2.AddGrade(76);
            student2.AddGrade(76);
            student2.AddGrade(76);

            student3.AddGrade(98);
            student3.AddGrade(94);
            student3.AddGrade(96);
            #endregion


            #region -- Application Manager --
            StudentService studentService = new StudentService();
            #endregion

            #region -- Registration of Students --
            // Using StudentService for Registration
            studentService.AddStudent(student1);
            studentService.AddStudent(student2);
            studentService.AddStudent(student3);
            #endregion

            #region -- Operations / Data Retrieval
            // retrieve the students 
            IReadOnlyList<Student> registeredStudents = studentService.GetAllStudents(); // updated for encapsulation 
            #endregion

            #region -- Display Outputs --

            DisplayStudentReport(registeredStudents);

            CheckingStudentById(studentService, 2); // Check student if existing by ID


            RemoveStudentById(studentService, 5); // Remove student by ID
            DisplayStudentReport(registeredStudents); // Display Student Report

            UpdateStudentInformation(student1, "Darryll J Pajaganas", "BSIT");

            DisplayStudentReport(registeredStudents); // checking if the student 1 updated

            //student1.Name = "New Name";

            #endregion
        }



        #region -- Functions --
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

        // Function fo displaying Student report 
        static void DisplayStudentReport(IReadOnlyList<Student>  registeredStudents)
        {
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

    }
}

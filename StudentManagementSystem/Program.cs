namespace StudentManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region -- Object Instantiation -- 
            Student student1 = new Student(1, "Darryll", "BSCS") 
            {
                Grades =
                {
                    90,
                    76,
                    87
                }
            };

            Student student2 = new Student(2, "Beji", "BSIT")
            {
                Grades =
                {
                    76,
                    76,
                    76
                }
            };

            Student student3 = new Student(1, "Celeine", "BSCE")
            {
                Grades =
                {
                    98,
                    94,
                    96
                }
            };


            #endregion

            #region -- Application Manager --
            StudentService studentService = new StudentService();
            #endregion

            #region -- Operations / Data Retrieval
            // retrieve the students 
            List<Student> registeredStudents = studentService.GetAllStudents(); // 
            #endregion

            #region -- Display Outputs --
            // Instantiate two Students
            // Simple not good for many data
            /*Console.WriteLine(student1.StudentID);
            Console.WriteLine(student1.Name);
            Console.WriteLine(student1.Course);
            Console.WriteLine("========================");
            Console.WriteLine(student2.StudentID);
            Console.WriteLine(student2.Name);
            Console.WriteLine(student2.Course);*/

            // Manual Registration
            //student1.AddGrade(90);
            //student1.AddGrade(76);
            //student1.AddGrade(87);

            //student2.AddGrade(76);
            //student2.AddGrade(76);
            //student2.AddGrade(76);

            // Using StudentService for Registration

            studentService.AddStudent(student1);
            studentService.AddStudent(student2);
            studentService.AddStudent(student3);

            foreach (var registeredstudent in registeredStudents)
            {
                DisplayStudent(registeredstudent);
            }

            Console.WriteLine("================================");
            Console.WriteLine("Checking student by Id");
            Console.WriteLine("================================");
            Student? student = studentService.GetStudentByID(2);

            if(student != null)
            {
                DisplayStudent(student);
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
            

            //DisplayStudent(student1);
            //Console.WriteLine();
            //DisplayStudent(student2);
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
            bool isPassed = average >= 75;

            Console.WriteLine($"Average: {average:F2}");
            Console.WriteLine($"Status: {(isPassed ? "PASSED" : "FAILED")}");

        }

        #endregion

    }
}

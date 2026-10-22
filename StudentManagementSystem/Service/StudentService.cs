using System.Reflection.Metadata.Ecma335;

namespace StudentManagementSystem
{
    public class StudentService
    {
        #region -- Field -- 
        // It is usually marked private so it can only be used internally.The underscore(_) in _students is the standard
        // C# naming convention specifically for private fields.
        private List<Student> _students = new List<Student>(); // collection for the student
        #endregion

        #region -- Method --

        public void AddStudent(Student student)
        {
            Student? existingStudent = GetStudentByID(student.StudentID); // Check if the ID already exists or hold nothing
            // To prevent duplicates
            if (existingStudent != null)
            {
               Console.WriteLine("Student ID already exist!");
               return;
            }
            _students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student? GetStudentByID(int studentId)
        {
            foreach (var student in _students)
            {
                if (student.StudentID == studentId)
                {
                    return student;
                }
            }
            return null;

        }

        #endregion
    }
}
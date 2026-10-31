using System.Reflection.Metadata.Ecma335;

namespace StudentManagementSystem.Service
{
    public class StudentService
    {
        #region -- Field -- 
        // It is usually marked private so it can only be used internally.The underscore(_) in _students is the standard
        // C# naming convention specifically for private fields.
        private List<Student> _students = new List<Student>(); // collection for the student
        #endregion

        #region -- Method --

        public bool AddStudent(Student student)
        {
            Student? existingStudent = GetStudentByID(student.StudentID); // Check if the ID already exists or hold nothing
            // To prevent duplicates
            if (existingStudent != null)
            {
               //Console.WriteLine("Student ID already exist!"); no need for this
               return false;
            }
            _students.Add(student);
            return true;
        }

        public IReadOnlyList<Student> GetAllStudents()
        {
            return _students.AsReadOnly();
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

        public bool RemoveStudent(int studentID)
        {
            Student? student = GetStudentByID(studentID);
            if(student == null) // checking if student is not existing
            {
                return false;
            }

            return _students.Remove(student);
            
        }

        public bool HasRegisteredStudents()
        {
            if(_students.Count > 0) // if student counts collection greater than 0 = empty list / no counts
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
using StudentManagementSystem.Validator;

namespace StudentManagementSystem
{
    public class Student
    {

        #region -- Properties --
        // A member that provides a flexible mechanism to read, write, or compute the value of a private field. 
        // Properties use get and set blocks (accessors). 
        public int StudentID { get; private set; } = 0;
        public string Name { get; private set; } = ""; // updated change setter to private
        public string Course { get; private set; } = ""; // updated change setter to private
        //public List<int> Grades { get; private set; } = new List<int>(); // collection for the grades

        private List<int> _grades = new List<int>();
        public IReadOnlyList<int> Grades => _grades.AsReadOnly();

        #endregion

        #region -- Constructors --
        public Student(int studentId,string name, string course)
        {
            this.StudentID = studentId;
            this.Name = name;
            this.Course = course;
        }
        #endregion

        #region -- Methods --
        public void AddGrade(int grade)
        {
            if(InputValidator.ValidateGrade(grade))
            {
                Console.WriteLine("Grade added!");
                _grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Only accepts grades from 70 - 100!");
                return;
            }
        }

        public double CalculateAverage()
        {
            double average;
            double totalSum = _grades.Sum();
            double elementsCount = 0;
            if (_grades.Count() == 0)
            {
                return 0.0;
            }
            else
            {
                elementsCount = _grades.Count();
            }
            
            return average = (totalSum / elementsCount);
        }

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

        public void UpdateStudentInfo(string name, string course)
        {
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(course))
            {
                Console.WriteLine("Update failed: Name and Course cannot be empty or just spaces!");
                return;
            }

            Name = name;
            Course = course;

            Console.WriteLine("Updated Successfully!");
        }

        #endregion
    }
}
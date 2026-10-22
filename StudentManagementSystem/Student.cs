namespace StudentManagementSystem
{
    public class Student
    {

        #region -- Properties --
        // A member that provides a flexible mechanism to read, write, or compute the value of a private field. 
        // Properties use get and set blocks (accessors). 
        public int StudentID { get; private set; } = 0;
        public string Name { get; set; } = "";
        public string Course { get; set; } = "";
        public List<int> Grades { get; private set; } = new List<int>(); // collection for the grades

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
            if((grade < 0) || (grade > 100))
            {
                Console.WriteLine("Only accepts grades from 0 - 100!");
                return;
            }
            else
            {
                Console.WriteLine("Grade added!");
                Grades.Add(grade);
            }
        }

        public double CalculateAverage()
        {
            double average;
            double totalSum = Grades.Sum();
            double elementsCount = 0;
            if (Grades.Count() == 0)
            {
                return 0.0;
            }
            else
            {
                elementsCount = Grades.Count();
            }
            
            return average = (totalSum / elementsCount);
        }

        public bool IsPassed()
        {
            double calculatedAverage = CalculateAverage();

            if(calculatedAverage == 0)
            {
                Console.WriteLine("No grades, Not pass!");
                return false;
            }
            else if(calculatedAverage >= 75)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
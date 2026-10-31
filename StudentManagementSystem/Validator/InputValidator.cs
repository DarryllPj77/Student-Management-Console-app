using System.Xml.Linq;

namespace StudentManagementSystem.Validator
{
    public class InputValidator
    {
        public static bool ValidateStudentID(int id)
        {
            if(id > 0)
            {
                return true; // Valid ID
            }
            else
            {
                return false; // Unvalid ID
            }
        }

        public static bool ValidateRequiredText(string? text, string validationType)
        {
            string? cleaned = text?.Trim();

            if (string.IsNullOrWhiteSpace(cleaned)) return false;

            switch (validationType.ToLower())
            {
                case "nametype":
                    return cleaned.Length >= 2 && cleaned.Length <= 70;
                case "coursetype":
                    return cleaned.Length >= 3 && cleaned.Length <= 120;
                default:
                    return false;
            }
        }

        public static bool ValidateGrade(int grade)
        {
            if(grade >=70 && grade <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

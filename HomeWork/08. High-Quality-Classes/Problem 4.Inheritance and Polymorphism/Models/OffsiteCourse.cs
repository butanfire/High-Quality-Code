namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : University
    {
        public OffsiteCourse(string courseName) : base(courseName)
        {
            Town = string.Empty;
        }

        public OffsiteCourse(string courseName, string teacherName) : base(courseName, teacherName)
        {
            Town = string.Empty;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students) : base(courseName, teacherName, students)
        {
            Town = string.Empty;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(CourseName);
            if (!string.IsNullOrEmpty(TeacherName))
            {
                result.Append("; Teacher = ");
                result.Append(TeacherName);
            }

            result.Append("; Students = ");
            result.Append(GetStudentsAsString());
            if (!string.IsNullOrEmpty(Town))
            {
                result.Append("; Town = ");
                result.Append(Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}

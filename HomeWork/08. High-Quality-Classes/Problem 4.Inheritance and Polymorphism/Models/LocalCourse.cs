namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : University
    {
        public LocalCourse(string courseName) : base(courseName)
        {
            Lab = string.Empty;
        }

        public LocalCourse(string courseName, string teacherName) : base(courseName, teacherName)
        {
            Lab = string.Empty;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students) : base(courseName, teacherName, students)
        {
            Lab = string.Empty;
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(CourseName);
            if (!string.IsNullOrEmpty(TeacherName))
            {
                result.Append("; Teacher = ");
                result.Append(TeacherName);
            }

            result.Append("; Students = ");
            result.Append(GetStudentsAsString());

            if (!string.IsNullOrEmpty(Lab))
            {
                result.Append("; Lab = ");
                result.Append(Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}

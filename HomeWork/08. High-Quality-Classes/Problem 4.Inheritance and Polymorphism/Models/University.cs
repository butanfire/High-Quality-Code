namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using DataValidation;

    public abstract class University
    {
        private string courseName;
        private string teacherName;

        public University(string courseName)
        {
            CourseName = courseName;
            Students = new List<string>();
        }

        public University(string courseName, string teacherName)
        {
            CourseName = courseName;
            TeacherName = teacherName;
            Students = new List<string>();
        }

        public University(string courseName, string teacherName, IList<string> students)
        {
            CourseName = courseName;
            TeacherName = teacherName;
            Students = students;
        }

        public string CourseName
        {
            get
            {
                return courseName;
            }

            set
            {
                if (Validator.NameValidator(value))
                {
                    courseName = value;
                }
            }
        }

        public string TeacherName
        {
            get
            {
                return teacherName;
            }

            set
            {
                if (Validator.NameValidator(value))
                {
                    teacherName = value;
                }
            }
        }

        public IList<string> Students { get; set; }

        public string GetStudentsAsString()
        {
            if (Students == null || Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", Students) + " }";
            }
        }
    }
}
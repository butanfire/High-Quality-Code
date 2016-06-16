namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int NameMinimumLength = 5;

        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Lectures = new List<Lecture>();
            this.Students = new HashSet<User>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
               if (string.IsNullOrEmpty(value) || value.Length < NameMinimumLength)
                {
                    string message = string.Format("The course name must be at least {0} symbols long.", NameMinimumLength);
                    throw new ArgumentException(message);
                }

                this.name = value;
            }
        }

        public List<Lecture> Lectures { get; set; }

        public HashSet<User> Students { get; set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
        }
    }
}

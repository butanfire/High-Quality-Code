namespace BangaloreUniversityLearningSystem.Models
{
    using BangaloreUniversityLearningSystem.Utilities;
    using System;
    using System.Collections.Generic;

    public class User
    {
        private const int UsernameMinimumLength = 5;
        private const int PasswordMinimumLength = 6;
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < UsernameMinimumLength)
                {
                    string message = string.Format("The username must be at least {0} symbols long.", UsernameMinimumLength);
                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.passwordHash;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < PasswordMinimumLength)
                {
                    string message = string.Format("The password must be at least {0} symbols long.", PasswordMinimumLength);
                    throw new ArgumentException(message);
                }

                this.passwordHash = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }

        public void EnrollCourses(Course course)
        {
            this.Courses.Add(course);
        }
    }
}

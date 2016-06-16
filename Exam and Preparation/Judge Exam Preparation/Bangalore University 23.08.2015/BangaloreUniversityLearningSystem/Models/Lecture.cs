namespace BangaloreUniversityLearningSystem.Models
{
    using System;

    public class Lecture
    {
        private const int LectureMinimumLength = 3;
        private string name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < LectureMinimumLength)
                {
                    string message = string.Format("The lecture name must be at least {0} symbols long.", LectureMinimumLength);
                    throw new ArgumentException(message);
                }

                this.name = value;
            }
        }
    }
}

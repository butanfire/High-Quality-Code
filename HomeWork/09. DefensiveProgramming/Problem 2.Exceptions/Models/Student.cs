namespace Exceptions_Homework.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null!");
                }

                this.lastName = value;
            }
        }

        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            ////pre-checks
            if (this.Exams == null || this.Exams.Count == 0)
            {
                throw new ArgumentNullException("Exam is empty or null!");
            }

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            ////post-checks
            Debug.Assert(this.Exams.Count == results.Count, "Result array is not correct!");

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            ////pre-checks
            if (this.Exams == null || this.Exams.Count == 0)
            {
                throw new ArgumentNullException("Exams is null or empty!");
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            ////post-checks
            Debug.Assert(examScore.Average() > 0, "Average value cannot be negative!");
            return examScore.Average();
        }
    }
}


namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using Core;
    using Models;
    using System;
    using System.Linq;
    using System.Text;

    public class Details : View
    {
        public Details(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.Model as Course;
            viewResult.AppendLine(courses.Name);

            if (!courses.Lectures.Any())
            {
                viewResult.AppendLine("No lectures");
            }
            else
            {
                viewResult.Append("- ");
                viewResult.Append(string.Join(Environment.NewLine + "- ", courses.Lectures.Select(s => s.Name)));
            }
        }
    }
}

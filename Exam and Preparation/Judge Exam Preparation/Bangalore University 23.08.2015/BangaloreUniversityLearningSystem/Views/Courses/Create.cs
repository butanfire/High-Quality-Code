namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using BangaloreUniversityLearningSystem.Core;
    using BangaloreUniversityLearningSystem.Models;
    using System.Text;

    public class Create : View
    {
        public Create(Course course) : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;

            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
}

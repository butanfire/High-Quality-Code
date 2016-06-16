namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Utilities;
    using Core;
    using Interfaces;
    using Models;

    public class CoursesController : Controller
    {
        public CoursesController(User user, IBangaloreUniversityData data) : base(user, data)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            return View(Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            this.EnsureAuthorization(Role.Lecturer, Role.Student);

            var course = this.CourseGetter(courseId);
            if (this.User.Courses.FirstOrDefault(c => c.Name == course.Name) == null)
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            return View(course);
        }

        public IView Enroll(int courseId)
        {
            EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = this.Data.Courses.Get(courseId);

            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.User);
            this.User.EnrollCourses(course);

            return View(course);
        }

        private Course CourseGetter(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);

            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            return course;
        }

        public IView Create(string name)
        {
            this.EnsureAuthorization(Role.Lecturer);

            var course = new Course(name);
            this.Data.Courses.Add(course);

            return View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            this.EnsureAuthorization(Role.Lecturer);

            Course course = CourseGetter(courseId);
            course.AddLecture(new Lecture(lectureName));

            return View(course);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangaloreUniversityLearningSystem.Data;
using BangaloreUniversityLearningSystem.Models;
using BangaloreUniversityLearningSystem.Core;
using BangaloreUniversityLearningSystem.Interfaces;
using BangaloreUniversityLearningSystem.Controllers;
using Moq;
using System.Linq;

namespace BULSTests
{
    public class DisplayTest : View
    {
        public DisplayTest(object model) : base(model)
        {
        }
    }

    [TestClass]
    public class BULSTests
    {
        [TestMethod]
        public void GetID_InvalidID_ShouldReturnDefault()
        {
            var data = new Repository<Lecture>();
            var lecture = data.Get(10);
            var expectedLecture = default(Lecture);
            Assert.AreEqual(expectedLecture, lecture);
        }

        [TestMethod]
        public void GetID_ValidID_ShouldReturnItem()
        {
            var data = new Repository<Lecture>();
            var someLecture = new Lecture("Pismenost");
            data.Add(someLecture);
            var expectedLecture = data.Get(1);

            Assert.AreEqual(expectedLecture, someLecture);
        }

        [TestMethod]
        public void Display_ValidData_WriteCorrectOutput()
        {
            var view = new DisplayTest(null);
            view.Display();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Logout_NoUserLogged_ShouldThrow()
        {
            var controller = new UsersController(null, null);
            var actualMessage = controller.Logout();
        }


        [TestMethod]
        public void Logout_UserLogged_ShouldLogoutCorrectly()
        {
            var loggedUser = new User("Pesho", "1234567", Role.Lecturer);
            var controller = new UsersController(loggedUser, null);
            var actualMessage = controller.Logout();
            var expectedMessage = string.Format("User {0} logged out successfully.", loggedUser.Username);
            Assert.AreEqual(expectedMessage, actualMessage.Display().ToString());
        }

        [TestMethod]
        public void CoursesAll_NoCourses_ReturnNoCourses()
        {
            var course = new Course("SomeCourse");
            var db = new BangaloreUniversityData();
            var loggedUser = new User("Pesho", "1234567", Role.Lecturer);
            var controller = new CoursesController(loggedUser, db);
            db.Courses.Add(course);

            var expectedMessage = string.Format("All courses:\r\n{0} (0 students)", course.Name).Trim();
            var actualMessage = controller.All().Display().ToString().Trim();
            Console.WriteLine(expectedMessage);
            Console.WriteLine(actualMessage);
            Assert.AreEqual(expectedMessage, actualMessage);

        }

        [TestMethod]
        public void CoursesAll_Courses_ReturnCourses()
        {
            var db = new BangaloreUniversityData();
            var loggedUser = new User("Pesho", "1234567", Role.Lecturer);
            var controller = new CoursesController(loggedUser, db);
            var actualMessage = controller.All().Display().ToString();
            var expectedMessage = "No courses.";

            Assert.AreEqual(expectedMessage, actualMessage);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MoqAddLecture_FailLogin_ShouldThrow()
        {
            var moqData = new Mock<IBangaloreUniversityData>();
            var moqCourseRepo = new Mock<IRepository<Course>>();

            moqCourseRepo.Setup(s => s.Get(It.IsAny<int>())).Returns(new Course("SomeCourse"));
            moqData.Setup(s => s.Courses).Returns(moqCourseRepo.Object);


            var controller = new CoursesController(null, moqData.Object);
            controller.AddLecture(1, "SomeCourse");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MoqAddLecture_InvalidCourseName_ShouldThrow()
        {
            var user = new User("Pesho", "12345678", Role.Lecturer);
            var moqData = new Mock<IBangaloreUniversityData>();
            var moqCourseRepo = new Mock<IRepository<Course>>();

            moqCourseRepo.Setup(s => s.Get(It.IsAny<int>())).Returns(new Course("So"));
            moqData.Setup(s => s.Courses).Returns(moqCourseRepo.Object);
            
            var controller = new CoursesController(user, moqData.Object);
            controller.AddLecture(1, "So");
        }

        [TestMethod]
        public void MoqAddLecture_ValidData_ShouldAddLectureCorrectly()
        {
            var course = new Course("SomeCourse");
            var lecture = new Lecture("Computers");
            var user = new User("Pesho", "12345678", Role.Lecturer);
            var moqData = new Mock<IBangaloreUniversityData>();
            var moqCourseRepo = new Mock<IRepository<Course>>();

            moqCourseRepo.Setup(s => s.Get(It.IsAny<int>())).Returns(course);
            moqData.Setup(s => s.Courses).Returns(moqCourseRepo.Object);
            var controller = new CoursesController(user, moqData.Object);   
                        
            var view = controller.AddLecture(1, lecture.Name);
            
            Assert.AreEqual(course.Lectures.First().Name, lecture.Name);
            Assert.IsNotNull(view);
        }
    }
}

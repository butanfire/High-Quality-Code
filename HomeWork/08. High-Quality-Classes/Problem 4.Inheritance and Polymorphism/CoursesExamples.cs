namespace InheritanceAndPolymorphism
{
    using Models;
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                "Mario Peshev", 
                new List<string> { "Thomas", "Ani", "Steve" });

            University softUni = new LocalCourse("Pesho C++");

            List<University> courseManager = new List<University> {offsiteCourse, localCourse, softUni};

            foreach (var item in courseManager)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

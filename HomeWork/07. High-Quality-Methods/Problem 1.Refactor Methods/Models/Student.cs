namespace Methods.Models
{
    using System;

    /// <summary>
    /// Class for creating Students.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Field for the Student birth date.
        /// </summary>
        private string birthDate;

        /// <summary>
        /// Property for the first name of the Student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Property the last name of the Student.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Property the birth date of the Student, in string format.
        /// </summary>
        public string BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Birth date cannot be empty/null");
                    }

                    birthDate = value;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    birthDate = string.Empty;
                }
            }
        }

        /// <summary>
        /// Function for comparing the age of two students.
        /// DateTime default parse format is "MM/DD/YYYY".
        /// </summary>
        /// <param name="studentOne">Student object, which contains a valid birth date</param>
        /// <param name="studentTwo">Student object, which contains a valid birth date</param>
        /// <returns>True, if studentOne is older. False, if studentTwo is older.</returns>
        public static bool CompareStudentAge(Student studentOne, Student studentTwo)
        {
            try
            {
                DateTime firstDate = new DateTime();
                DateTime secondDate = new DateTime();
                if (!DateTime.TryParse(studentOne.BirthDate, out firstDate) || !DateTime.TryParse(studentTwo.BirthDate, out secondDate))
                {
                    throw new ArgumentException("Incorrect birth date format");
                }

                return firstDate > secondDate;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

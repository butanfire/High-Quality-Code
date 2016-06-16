namespace Methods
{
    using System;
    using Models;
    using Utils;

    /// <summary>
    /// Main class.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(MathMethods.CalcTriangleArea(3, 4, 5));
            Console.WriteLine(NumberConversion.NumberToString(5));
            Console.WriteLine(MathMethods.FindMax(5, -1, 3, 2, 14, 2, 3));

            NumberConversion.PrintFormattedNumber(1.3, "f");
            NumberConversion.PrintFormattedNumber(0.75, "%");
            NumberConversion.PrintFormattedNumber(2.30, "r");

            Console.WriteLine(MathMethods.CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + MathMethods.IsHorizontal(3, 3));
            Console.WriteLine("Vertical? " + MathMethods.IsVertical(-1, 2.5));

            Student peter = new Student
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                BirthDate = "03.17.1992"
            };
            ////DateTime default parse format is "MM/DD/YYYY";
            Student stella = new Student
            {
                FirstName = "Stella",
                LastName = "Markova",
                BirthDate = "11.03.1993"
            };

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                Student.CompareStudentAge(peter, stella));

            Console.WriteLine();
            ////trying to break the methods

            Console.WriteLine(MathMethods.CalcTriangleArea(-3, -4, -5));
            Console.WriteLine(NumberConversion.NumberToString(55));
            Console.WriteLine(MathMethods.FindMax());
            NumberConversion.PrintFormattedNumber(1.3, "SM");
            NumberConversion.PrintFormattedNumber(0.75, "LM");
            NumberConversion.PrintFormattedNumber(2.30, "RM");
            Student pesho = new Student() { FirstName = "Pesho", LastName = "Peshev", BirthDate = "" };
            Console.WriteLine(Student.CompareStudentAge(peter, pesho));

        }
    }
}

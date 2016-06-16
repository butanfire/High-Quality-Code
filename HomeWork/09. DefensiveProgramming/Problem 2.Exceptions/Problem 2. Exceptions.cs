namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class Exceptions
    {
        static void Main()
        {
            try
            {
                var substr = Utils.Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = Utils.Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(String.Join(" ", subarr));

                var allarr = Utils.Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
                Console.WriteLine(String.Join(" ", allarr));

                var emptyarr = Utils.Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(String.Join(" ", emptyarr));

                Console.WriteLine(Utils.Utils.ExtractEnding("I love C#", 2));
                Console.WriteLine(Utils.Utils.ExtractEnding("Nakov", 4));
                Console.WriteLine(Utils.Utils.ExtractEnding("beer", 4));
                Console.WriteLine(Utils.Utils.ExtractEnding("Hi", 100));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //I perform a try statement again, otherwise we will skip all the examples. (because the exception jumps to the catch statement)
            try
            {
                Utils.Utils.CheckPrime(23);
                Utils.Utils.CheckPrime(33);

                List<Exam> peterExams = new List<Exam>()
                {
                    new SimpleMathExam(2),
                    new CSharpExam(55),
                    new CSharpExam(100),
                    new SimpleMathExam(1),
                    new CSharpExam(0),
                };

                Student peter = new Student("Peter", "Petrov", peterExams);
                double peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

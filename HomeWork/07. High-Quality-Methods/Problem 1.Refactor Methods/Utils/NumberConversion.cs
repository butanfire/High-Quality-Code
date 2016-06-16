namespace Methods.Utils
{
    using System;

    public static class NumberConversion
    {
        /// <summary>
        /// Converts the number from 0 - 10 to string.
        /// </summary>
        /// <param name="number">The number to be converted.</param>
        /// <returns>String representation of the number.</returns>
        public static string NumberToString(int number)
        {
            try
            {
                if (number < 10)
                {
                    switch (number)
                    {
                        case 0:
                            return "zero";
                        case 1:
                            return "one";
                        case 2:
                            return "two";
                        case 3:
                            return "three";
                        case 4:
                            return "four";
                        case 5:
                            return "five";
                        case 6:
                            return "six";
                        case 7:
                            return "seven";
                        case 8:
                            return "eight";
                        case 9:
                            return "nine";
                        default:
                            throw new ArgumentException("Number provided should be lower than 10");
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }

            return string.Empty;
        }

        /// <summary>
        /// Function for printing a number in a specified format.
        /// </summary>
        /// <param name="number">The number to be printed.</param>
        /// <param name="format">The format used for printing.</param>
        public static void PrintFormattedNumber(object number, string format)
        {
            try
            {
                switch (format)
                {
                    case "f":
                        Console.WriteLine("{0:f2}", number);
                        break;
                    case "%":
                        Console.WriteLine("{0:p0}", number);
                        break;
                    case "r":
                        Console.WriteLine("{0,8}", number);
                        break;
                    default:
                        throw new InvalidOperationException("No such print command exists");
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

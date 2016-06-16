using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions_Homework.Utilities
{
    public static class Utils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            ////pre-checks
            if (count < 0 || count > arr.Length)
            {
                throw new ArgumentException("Invalid count number provided for Subsequence!");
            }

            if (startIndex < 0)
            {
                throw new IndexOutOfRangeException("Start index cannot be negative!");
            }

            if (arr.Length < 0 || arr == null)
            {
                throw new ArgumentNullException("Array for Subsequence is empty or null!");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            ////post-checks
            Debug.Assert(result.Count == count, "The resulting subsequence is not correct!");

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            ////pre-checks
            if (count > str.Length)
            {
                throw new ArgumentException("Count cannot be more than the string length");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            ////post-checks
            Debug.Assert(result.Length == count, "The substring is not correct!");

            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    Console.WriteLine("Number {0} is not prime!", number);
                }
            }
        }
    }
}

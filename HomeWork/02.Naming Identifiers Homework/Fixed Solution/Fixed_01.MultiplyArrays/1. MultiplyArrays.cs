namespace MultiplyArray
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var randomArray = new double[,] { { 1, 3 }, { 5, 7 } };
            var randomArrayFriend = new double[,] { { 4, 2 }, { 1, 5 } };
            var resultArray = MultiplyArray(randomArray, randomArrayFriend);

            for (int i = 0; i < resultArray.GetLength(0); i++)
            {
                for (int j = 0; j < resultArray.GetLength(1); j++)
                {
                    Console.Write(resultArray[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        static double[,] MultiplyArray(double[,] firstArray, double[,] secondArray)
        {
            if (firstArray.GetLength(1) != secondArray.GetLength(0))
            {
                throw new IndexOutOfRangeException("Error!");
            }

            var resultArray = new double[firstArray.GetLength(0), secondArray.GetLength(1)];

            for (int iterator1 = 0; iterator1 < resultArray.GetLength(0); iterator1++)
            {
                for (int iterator2 = 0; iterator2 < resultArray.GetLength(1); iterator2++)
                {
                    for (int iterator3 = 0; iterator3 < firstArray.GetLength(1); iterator3++)
                    {
                        resultArray[iterator1, iterator2] += firstArray[iterator1,iterator3] * secondArray[iterator3, iterator2];
                    }
                }
            }

            return resultArray;
        }
    }
}
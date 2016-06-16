namespace CompareSortingAlgorithms
{
    using System.Diagnostics;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public const int valueChallenge = 1000000; //how many numbers will the array contain/ will be added via the Populate Array.

        public static Random random = new Random();

        public static int[] PopulateArray(int[] array)
        {
            for (int i = 0; i < valueChallenge; i++)
            {
                array[i] = random.Next(0, valueChallenge);
            }

            return array;
        }

        public static void PrintArray(ref int[] array)
        {
            for (int i = 0; i < valueChallenge; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            int[] array = new int[valueChallenge]; //array used for the sorting

            List<double> measurement = new List<double>(); //list for taking the measurements
            Stopwatch watch = new Stopwatch();
            for (int i = 0; i < 10; i++) //how many times should we take the measurements.
            {                
                array = PopulateArray(array); //re-populate the array
                watch.Start();

                InsertionSort(array); //comment in/out the desired algorithm, usually a class system could be used for selecting the sorting algorithm
                //SelectionSort(array);
                //MergeSort_Recursive(array, 0, valueChallenge - 1);
                //QuickSort(array, 0, valueChallenge - 1);
                measurement.Add(watch.Elapsed.TotalMilliseconds);               
                watch.Restart();
            }

            Console.WriteLine(measurement.Average());
        }

        /// <summary>
        /// I took the sorting algorithms from the internet.
        /// It would be better if i wrote them, but didn`t have the time.
        /// They shouldn`t be far off in terms of execution for the time comparisons.
        /// </summary>

        public static void InsertionSort(int[] array)
        {
            for (int i = 0; i < valueChallenge - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < valueChallenge - 1; i++)
            {
                var pos_min = i;

                for (int j = i + 1; j < valueChallenge; j++)
                {
                    if (array[j] < array[pos_min])
                    {
                        pos_min = j;
                    }
                }

                if (pos_min != i)
                {
                    var temp = array[i];
                    array[i] = array[pos_min];
                    array[pos_min] = temp;
                }
            }
        }

        public static void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[valueChallenge];
            int i;

            var left_end = (mid - 1);
            var tmp_pos = left;
            var num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        public static void MergeSort_Recursive(int[] numbers, int left, int right)
        {
            if (right > left)
            {
                var mid = (right + left) / 2;
                MergeSort_Recursive(numbers, left, mid);
                MergeSort_Recursive(numbers, (mid + 1), right);

                DoMerge(numbers, left, (mid + 1), right);
            }
        }

        public static void QuickSort(int[] array, int left, int right)
        {
            int i = left, j = right;
            int pivot = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(array, left, j);
            }

            if (i < right)
            {
                QuickSort(array, i, right);
            }
        }
    }
}

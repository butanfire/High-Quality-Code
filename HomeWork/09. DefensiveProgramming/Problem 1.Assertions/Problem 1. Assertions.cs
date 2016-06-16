namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    public class Assertions
    {
        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            ////pre-checks
            if (!(arr.Length > 0) || arr == null)
            {
                throw new ArgumentNullException("Cannot perform Selection Sort for empty array.");
            }

            if (startIndex < 0 || endIndex < 0 || startIndex > arr.Length || endIndex > arr.Length)
            {
                throw new IndexOutOfRangeException("Invalid start/end index!");
            }

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            ////post-check
            for (int i = startIndex; i <= endIndex; i++)
            {
                if(arr[minElementIndex].CompareTo(arr[i]) == 0)
                {
                    continue;
                }

                int s = arr[minElementIndex].CompareTo(arr[i]);
                Debug.Assert(s < 0, "The min element is incorrect!");
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            ////pre-checks
            if (!(arr.Length > 0) || arr == null)
            {
                throw new ArgumentNullException("Cannot perform Selection Sort for empty array.");
            }

            if (startIndex < 0 || endIndex < 0 || startIndex > arr.Length || endIndex > arr.Length)
            {
                throw new IndexOutOfRangeException("Invalid start/end index!");
            }

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            if (!(arr.Length > 0) || arr == null)
            {
                throw new ArgumentNullException("Cannot perform Selection Sort for empty array.");
            }

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            ////pre-checks
            if (!(arr.Length > 0) || arr == null)
            {
                throw new ArgumentNullException("Cannot perform Selection Sort for empty array.");
            }

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            ////post-check
            for (int i = 1; i < arr.Length; i++)
            {
                int s = arr[i-1].CompareTo(arr[i]);
                Debug.Assert(s < 0, "The array is not ordered correctly!");
            }
        }

        public static void Main()
        {
            try
            {
                int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
                Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
                SelectionSort(arr);
                Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

                SelectionSort(new int[0]); // Test sorting empty array
                SelectionSort(new int[1]); // Test sorting single element array

                Console.WriteLine(BinarySearch(arr, -1000));
                Console.WriteLine(BinarySearch(arr, 0));
                Console.WriteLine(BinarySearch(arr, 17));
                Console.WriteLine(BinarySearch(arr, 10));
                Console.WriteLine(BinarySearch(arr, 1000));
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

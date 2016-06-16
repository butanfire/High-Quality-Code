namespace Methods.Utils
{
    using System;

    public static class MathMethods
    {
        /// <summary>
        /// Function for calculating the area of a triangle
        /// </summary>
        /// <param name="a">Side A length.</param>
        /// <param name="b">Side B length.</param>
        /// <param name="c">Side C length.</param>
        /// <returns>The area of the Triangle</returns>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            try
            {
                if (a <= 0 || b <= 0 || c <= 0)
                {
                    throw new ArgumentException("No such triangle exists");
                }

                if (a + b > c && a + c > b && b + c > a)
                {
                    double s = (a + b + c) / 2;
                    double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                    return area;
                }

                throw new ArgumentException("No such triangle exists");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Function for finding the maximum number in the array.
        /// </summary>
        /// <param name="elements">The array of numbers to find the Maximum number.</param>
        /// <returns>The maximum number from the array.</returns>
        public static int FindMax(params int[] elements)
        {
            try
            {
                if (elements == null || elements.Length == 0)
                {
                    throw new ArgumentNullException("The number/elements array provided is empty");
                }

                int max = 0;
                for (int i = 0; i < elements.Length; i++)
                {
                    max = Math.Max(elements[i], max);
                }

                return max;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Function for calculating the distance between two points.
        /// </summary>
        /// <param name="x1">x1 coordinate of Point 1.</param>
        /// <param name="y1">y1 coordinate of Point 1.</param>
        /// <param name="x2">x2 coordinate of Point 2.</param>
        /// <param name="y2">y2 coordinate of Point 2.</param>
        /// <returns>The distance between the two Points.</returns>
        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        /// <summary>
        /// Method for checking whether the points are horizontal.
        /// </summary>
        /// <param name="y1">y1 parameter from Point 1.</param>
        /// <param name="y2">y2 parameter from Point 2.</param>
        /// <returns>True if they are horizontal. False if they are not horizontal.</returns>
        public static bool IsHorizontal(double y1, double y2)
        {
            return y1 == y2;
        }

        /// <summary>
        /// Method for checking whether the points are vertical.
        /// </summary>
        /// <param name="x1">x1 parameter from Point 1.</param>
        /// <param name="x2">x2 parameter from Point 1.</param>
        /// <returns>True if they are vertical. False if they are not vertical.</returns>
        public static bool IsVertical(double x1, double x2)
        {
            return x1 == x2;
        }

    }
}

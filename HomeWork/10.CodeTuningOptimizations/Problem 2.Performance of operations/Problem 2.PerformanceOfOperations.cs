namespace PerformanceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            List<double> measurementInt = new List<double>(); //lists for taking the measurement time for each data type, so we can average it.
            List<double> measurementLong = new List<double>();
            List<double> measurementDouble = new List<double>();
            List<double> measurementDecimal = new List<double>();

            //decided not to use functions for the 'for-loops' to avoid call to the function stack
            for (int s = 0; s < 100; s++) //performing 100 measurements
            {
                watch.Start();
                ////double
                double sumDouble = 0;
                for (double i = 1; i < 500; i++) //performing 500 operations with the respective operand/math function/data type
                {
                    sumDouble = Math.Sin(i);
                }
                measurementDouble.Add(watch.Elapsed.TotalMilliseconds);
                watch.Restart();

                ////decimal
                decimal sumDecimal = 0;

                for (double i = 1; i < 500; i++)
                {
                    sumDecimal = (decimal) Math.Sin(i);
                }

                measurementDecimal.Add(watch.Elapsed.TotalMilliseconds);
                watch.Stop();
            }
            
            Console.WriteLine("Double : {0}",measurementDouble.Average());
            Console.WriteLine("Decimal: {0}",measurementDecimal.Average());
        }
    }
}

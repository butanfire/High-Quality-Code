namespace CohesionAndCoupling.Exceptions
{
    using System;

    public class NumericDataException : ArgumentException
    {
        public NumericDataException(string message) : base(message)
        {
        }
    }
}

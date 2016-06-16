namespace Abstraction.Exceptions
{
    using System;

    public class NumericNegativeException : ArgumentException
    {
        public NumericNegativeException(string message) : base(message)
        {
        }
    }
}

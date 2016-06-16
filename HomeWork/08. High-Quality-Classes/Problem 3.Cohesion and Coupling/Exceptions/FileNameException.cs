namespace CohesionAndCoupling.Exceptions
{
    using System;

    public class FileNameException : ArgumentException
    {
        public FileNameException(string message) : base(message)
        {
        }
    }
}

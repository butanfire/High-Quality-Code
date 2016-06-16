namespace CohesionAndCoupling.Exceptions
{
    using System;

    public class FileExtensionException : ArgumentException
    {
        public FileExtensionException(string message) : base(message)
        {
        }
    }
}

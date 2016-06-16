namespace InheritanceAndPolymorphism.Exception
{
    using System;

    public class NameException : ArgumentException
    {
        public NameException(string message) : base(message)
        {
        }
    }
}

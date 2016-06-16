namespace AirConditionerTestingSystem.Exceptions
{
    using System;

    public class DuplicateEntryException : ArgumentException
    {
        public DuplicateEntryException(string message) : base(message)
        {
        }
    }
}

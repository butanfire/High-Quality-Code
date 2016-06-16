namespace AirConditionerTestingSystem.Exceptions
{
    using System;

    public class NonExistantEntryException : Exception
    {
        public NonExistantEntryException(string message) : base(message)
        {
        }
    }
}

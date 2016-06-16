namespace AirConditionerTestingSystem.Core.IO
{
    using System;
    using AirConditionerTestingSystem.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}

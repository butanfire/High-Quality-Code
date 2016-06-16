namespace AirConditionerTestingSystem.Core.IO
{
    using System;
    using AirConditionerTestingSystem.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

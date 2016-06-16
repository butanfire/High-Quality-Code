namespace AirConditionerTestingSystem
{
    using AirConditionerTestingSystem.Core;
    using AirConditionerTestingSystem.Core.IO;
    using AirConditionerTestingSystem.Data;

    public class Program
    {
        public static void Main()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var database = new Database();

            var engine = new Engine(writer, reader, database);
            engine.Run();
        }
    }
}

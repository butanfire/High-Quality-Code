namespace AirConditionerTestingSystem.Core
{
    using System;
    using AirConditionerTestingSystem.Data;
    using AirConditionerTestingSystem.Exceptions;
    using AirConditionerTestingSystem.Interfaces;

    public class Engine
    {
        private Controller controller;
        private Database database;
        private IWriter writer;
        private IReader reader;
        private CommandManager commandManager;

        public Engine(IWriter writer, IReader reader, Database database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
            this.controller = new Controller(this.database, this.writer);
        }

        public void Run()
        {
            while (true)
            {
                string line = this.reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();

                try
                {
                    this.commandManager = new CommandManager(line);
                    this.controller.ParseCommands(this.commandManager);
                }
                catch (NonExistantEntryException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (DuplicateEntryException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}

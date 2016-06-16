namespace AirConditionerTestingSystem.Interfaces
{
    using System;
    using AirConditionerTestingSystem.Utilities;

    public class CommandManager
    {
        public CommandManager(string line)
        {
            this.CommandParsing(line);
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }

        public void CommandParsing(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(' '));
                this.Parameters = line.Substring(line.IndexOf('('))
                .Split(new char[] { '(', ')', ',' },
                StringSplitOptions.RemoveEmptyEntries);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }
        }
    }
}

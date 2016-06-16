namespace BoatRacingSimulator.Core
{
    using System;
    using Controllers;
    using Enumerations;
    using Interfaces;
    using Utility;

    public class CommandHandler : ICommandHandler
    {
        public CommandHandler(IBoatSimulatorController controller)
        {
            Controller = controller;
        }

        public CommandHandler() : this(new BoatSimulatorController())
        {
        }

        public IBoatSimulatorController Controller { get; }

        public string ExecuteCommand(string name, string[] parameters)
        {
            switch (name)
            {
                case "CreateBoatEngine":
                    EngineType engineType;
                    if (Enum.TryParse(parameters[3], out engineType))
                    {
                        return Controller.CreateBoatEngine(
                        parameters[0],
                        int.Parse(parameters[1]),
                        int.Parse(parameters[2]),
                        engineType);
                    }

                    throw new ArgumentException(Constants.IncorrectEngineTypeMessage);
                    
                case "CreateRowBoat":
                    return Controller.CreateRowBoat(
                        parameters[0],
                        int.Parse(parameters[1]),
                        int.Parse(parameters[2]));
                case "CreateSailBoat":
                    return Controller.CreateSailBoat(
                        parameters[0],
                        int.Parse(parameters[1]),
                        int.Parse(parameters[2]));
                case "CreatePowerBoat":
                    return Controller.CreatePowerBoat(
                        parameters[0],
                        int.Parse(parameters[1]),
                        parameters[2],
                        parameters[3]);
                case "CreateYacht":
                    return Controller.CreateYacht(
                        parameters[0],
                        int.Parse(parameters[1]),
                        parameters[2],
                        int.Parse(parameters[3]));
                case "OpenRace":
                    return Controller.OpenRace(
                        int.Parse(parameters[0]),
                        int.Parse(parameters[1]),
                        int.Parse(parameters[2]),
                        bool.Parse(parameters[3]));
                case "SignUpBoat":
                    return Controller.SignUpBoat(parameters[0]);
                case "StartRace":
                    return Controller.StartRace();
                case "GetStatistic":
                    return Controller.GetStatistic();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}

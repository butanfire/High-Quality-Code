namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Database;
    using Enumerations;    
    using Interfaces;
    using Models;
    using Utility;
    using Exceptions;
    using Models.Boats;
    using Models.Engines;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(BoatSimulatorDatabase database, IRace currentRace)
        {
            Database = database;
            CurrentRace = currentRace;
        }

        public BoatSimulatorController() : this(new BoatSimulatorDatabase(), null)
        {
        }

        public IRace CurrentRace { get; private set; }

        public BoatSimulatorDatabase Database { get; }

        /// <summary>
        /// Function for creating an engine in the Engine database.
        /// </summary>
        /// <param name="model">The model name of the engine</param>
        /// <param name="horsepower">Horsepower of the engine</param>
        /// <param name="displacement">Displacement of the engine</param>
        /// <param name="engineType">The type of the engine</param>
        /// <returns>Returns successful message if added correctly or exception</returns>
        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            Engines engine;
            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new JetEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SterndriveEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new NotImplementedException();
            }

            Database.Engines.Add(engine);
            return string.Format(
                "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.",
                model,
                horsepower,
                displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            var boat = new RowBoat(model, weight, oars);
            Database.Boats.Add(boat);
            return string.Format("Row boat with model {0} registered successfully.", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            var boat = new SailBoat(model, weight, sailEfficiency);
            Database.Boats.Add(boat);
            return string.Format("Sail boat with model {0} registered successfully.", model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            JetEngine firstEngine = Database.Engines.GetItem(firstEngineModel) as JetEngine;
            if (firstEngine == null)
            {
                firstEngine = Database.Engines.GetItem(secondEngineModel) as JetEngine;
            }

            SterndriveEngine secondEngine = Database.Engines.GetItem(secondEngineModel) as SterndriveEngine;

            if (secondEngine == null)
            {
                secondEngine = Database.Engines.GetItem(firstEngineModel) as SterndriveEngine;
            }

            var boat = new PowerBoat(model, weight, new List<JetEngine>() { firstEngine }, new List<SterndriveEngine>() { secondEngine });

            Database.Boats.Add(boat);
            return string.Format("Power boat with model {0} registered successfully.", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            JetEngine engine = Database.Engines.GetItem(engineModel) as JetEngine;
            var boat = new Yacht(model, weight, cargoWeight, new List<JetEngine>() { engine });
            Database.Boats.Add(boat);
            return string.Format("Yacht with model {0} registered successfully.", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            ValidateDuplicateRace();
            CurrentRace = race;
            return string.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                    distance, 
                    windSpeed, 
                    oceanCurrentSpeed);
        }

        /// <summary>
        /// Function for adding a boat to an active race.
        /// </summary>
        /// <param name="model">The model of the boat to be added</param>
        /// <returns>Successful message if added correctly or exception</returns>
        public string SignUpBoat(string model)
        {
            MotorBoat boat = Database.Boats.GetItem(model);
            ValidateRace();
            if (!CurrentRace.AllowsMotorboats && (boat is PowerBoat || boat is PowerBoat || boat is Yacht))
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            CurrentRace.AddParticipant(boat);
            return string.Format("Boat with model {0} has signed up for the current Race.", model);
        }
       
        public string StartRace()
        {
            ValidateRace();
            var participants = CurrentRace.GetParticipants();
            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var first = FindFastest(participants);
            participants.Remove(first.Key);
            var second = FindFastest(participants);
            participants.Remove(second.Key);
            var third = FindFastest(participants);
            participants.Remove(third.Key);

            var result = new StringBuilder();
            result.Append(PrintWinner(first, "First"));
            result.Append(PrintWinner(second, "Second"));
            result.Append(PrintWinner(third, "Third"));

            CurrentRace = null;

            return result.ToString();
        }

        public string PrintWinner(KeyValuePair<MotorBoat, double> contestant, string pos)
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("{3} place: {0} Model: {1} Time: {2}",
               contestant.Key.GetType().Name,
               contestant.Key.Model,
               contestant.Value < 0 ? "Did not finish!" : contestant.Value.ToString("0.00") + " sec",
               pos));

            return result.ToString();
        }

        public string GetStatistic()
        {
            var participants = CurrentRace.GetParticipants();
            Dictionary<string, double> stats = new Dictionary<string, double>();
            stats.Add("PowerBoat", 0);
            stats.Add("RowBoat", 0);
            stats.Add("SailBoat", 0);
            stats.Add("Yacht", 0);
            foreach (var participant in participants)
            {
                if (stats.ContainsKey(participant.GetType().Name))
                {
                    stats[participant.GetType().Name]++;
                }
            }
            
            StringBuilder result = new StringBuilder();
            foreach (var stat in stats.OrderBy(s => s.Key))
            {
                result.Append(string.Format(
                    "\n{0} -> {1:F2}%",
                    stat.Key,
                    (stat.Value / participants.Count) * 100));
            }

            return result.ToString();
        }

        private KeyValuePair<MotorBoat, double> FindFastest(IList<MotorBoat> participants)
        {
            double bestTime = double.MaxValue;
            MotorBoat winner = participants.FirstOrDefault();
            foreach (var participant in participants)
            {
                var speed = participant.CalculateRaceSpeed(CurrentRace);
                var time = CurrentRace.Distance / speed;
                if (time <= bestTime && time > 0)
                {
                    bestTime = time;
                    winner = participant;
                }
            }

            if (bestTime == double.MaxValue)
            {
                bestTime = -1;
            }

            return new KeyValuePair<MotorBoat, double>(winner, bestTime);
        }

        private void ValidateRace()
        {
            if (CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateDuplicateRace()
        {
            if (CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}

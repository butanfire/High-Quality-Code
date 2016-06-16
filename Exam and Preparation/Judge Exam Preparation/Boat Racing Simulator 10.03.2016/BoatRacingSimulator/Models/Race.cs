namespace BoatRacingSimulator.Models
{
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;
    using Utility;

    public class Race : IRace
    {
        private int distance;

        public Race(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            Distance = distance;
            WindSpeed = windSpeed;
            OceanCurrentSpeed = oceanCurrentSpeed;
            AllowsMotorboats = allowsMotorboats;
            RegisteredBoats = new Dictionary<string, MotorBoat>();
        }

        public int Distance
        {
            get
            {
                return distance;
            }

            private set
            {
                Validator.ValidateNegativeValue(value, "Distance");
                distance = value;
            }
        }

        public int WindSpeed { get; }

        public int OceanCurrentSpeed { get; }

        public bool AllowsMotorboats { get; }

        protected Dictionary<string, MotorBoat> RegisteredBoats { get; set; }

        public void AddParticipant(MotorBoat boat)
        {
            if (RegisteredBoats.ContainsKey(boat.Model))
            {
                throw new DuplicateModelException(Constants.DuplicateModelMessage);
            }

            RegisteredBoats.Add(boat.Model, boat);
        }

        public IList<MotorBoat> GetParticipants()
        {
            return new List<MotorBoat>(RegisteredBoats.Values);
        }
    }
}

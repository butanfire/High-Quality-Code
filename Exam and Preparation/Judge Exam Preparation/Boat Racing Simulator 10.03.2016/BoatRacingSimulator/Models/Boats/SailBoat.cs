namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using Interfaces;
    using Utility;

    public class SailBoat : MotorBoat
    {
        private int sailEfficiency;

        public SailBoat(string model, int weight) : base(model, weight)
        {
        }

        public SailBoat(string model, int weigth, int sailEfficiency) : this(model, weigth)
        {
            SailEfficiency = sailEfficiency;
        }

        public int SailEfficiency
        {
            get
            {
                return sailEfficiency;
            }

            private set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException(Constants.IncorrectSailEfficiencyMessage);
                }

                sailEfficiency = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            return (race.WindSpeed * (SailEfficiency / 100d)) - Weight + (race.OceanCurrentSpeed / 2d);;
        }
    }
}

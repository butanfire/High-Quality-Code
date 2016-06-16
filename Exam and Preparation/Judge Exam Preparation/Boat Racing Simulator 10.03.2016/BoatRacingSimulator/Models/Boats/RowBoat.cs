namespace BoatRacingSimulator.Models.Boats
{
    using Interfaces;
    using Utility;

    public class RowBoat : MotorBoat
    {
        private int oars;

        public RowBoat(string model, int weight) : base(model, weight)
        {
        }

        public RowBoat(string model, int weigth, int oars) : this(model, weigth)
        {
            Oars = oars;
        }

        public int Oars
        {
            get
            {
                return oars;
            }

            private set
            {
                Validator.ValidateNegativeValue(value, "Oars");
                oars = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            return (Oars * 100) - Weight + race.OceanCurrentSpeed;
        }
    }
}

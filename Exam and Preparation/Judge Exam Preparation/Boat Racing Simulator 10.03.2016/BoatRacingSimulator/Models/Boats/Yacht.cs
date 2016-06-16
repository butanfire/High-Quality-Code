namespace BoatRacingSimulator.Models.Boats
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Engines;
    using Utility;    

    public class Yacht : MotorBoat
    {
        private int cargoWeight;

        public Yacht(string model, int weight) : base(model, weight)
        {
        }

        public Yacht(string model, int weigth, int cargoweigth, IList<JetEngine> jetEngines) : this(model, weigth)
        {            
            CargoWeight = cargoweigth;
            JetEngines = jetEngines;
        }

        public int CargoWeight
        {
            get
            {
                return cargoWeight;
            }

            private set
            {
                Validator.ValidateNegativeValue(value, "Cargo Weight");
                cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var jet = JetEngines.Sum(x => x.Output);
            return jet - (Weight + CargoWeight) + (race.OceanCurrentSpeed / 2d);
        }
    }
}

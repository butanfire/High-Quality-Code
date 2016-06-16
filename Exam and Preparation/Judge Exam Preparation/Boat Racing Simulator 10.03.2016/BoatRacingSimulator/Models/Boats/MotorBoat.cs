namespace BoatRacingSimulator.Models
{
    using System.Collections.Generic;
    using Interfaces;
    using Utility;    
    using Engines;

    public abstract class MotorBoat : IModelable
    {
        private string model;

        private int weight;

        public MotorBoat(string model, int weight)
        {
            Model = model;
            Weight = weight;
        }

        public string Model
        {
            get
            {
                return model;
            }

            protected set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatModelLength);
                model = value;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }

            protected set
            {
                Validator.ValidateNegativeValue(value, "Weight");
                weight = value;
            }
        }

        protected IList<JetEngine> JetEngines { get; set; }

        protected IList<SterndriveEngine> SterndriveEngines { get; set; }

        public abstract double CalculateRaceSpeed(IRace race);        
    }
}

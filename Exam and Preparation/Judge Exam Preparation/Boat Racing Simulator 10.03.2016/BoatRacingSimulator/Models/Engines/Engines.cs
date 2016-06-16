namespace BoatRacingSimulator.Models.Engines
{
    using Interfaces;
    using Utility;

    public abstract class Engines : IModelable
    {
        private string model;

        private int horsepower;

        private int displacement;

        public int Output { get; set; }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                model = value;
            }
        }

        protected int Horsepower
        {
            get
            {
                return horsepower;
            }

            set
            {
                Validator.ValidateNegativeValue(value, "Horsepower");
                horsepower = value;
            }
        }

        protected int Displacement
        {
            get
            {
                return displacement;
            }

            set
            {
                Validator.ValidateNegativeValue(value, "Displacement");
                displacement = value;
            }
        }
    }
}

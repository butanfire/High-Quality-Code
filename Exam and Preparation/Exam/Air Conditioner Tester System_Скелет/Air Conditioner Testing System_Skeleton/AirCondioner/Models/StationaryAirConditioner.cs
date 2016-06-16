namespace AirConditionerTestingSystem.Models
{
    using System;
    using AirConditionerTestingSystem.Utilities;

    public class StationaryAirConditioner : AirConditioner
    {
        private int powerUsage;

        private string energyEfficiencyRating;

        public StationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.PowerUsage = powerUsage;
            this.EnergyEfficiencyRating = energyEfficiencyRating;
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NONPOSITIVE, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        private string EnergyEfficiencyRating
        {
            get
            {
                return this.energyEfficiencyRating;
            }

            set
            {
                switch (value)
                {
                    case "A":
                    case "B":
                    case "C":
                    case "D":
                    case "E":
                        this.energyEfficiencyRating = value;
                        break;
                    default:
                        throw new ArgumentException(Constants.INCORRECTRATING);
                }
            }
        }

        public override int Test()
        {
            bool condition = false;

            switch (this.EnergyEfficiencyRating)
            {
                case "A":
                    condition = this.PowerUsage < 1000;
                    break;
                case "B":
                    condition = this.PowerUsage < 1000 || (this.PowerUsage >= 1000 && this.PowerUsage <= 1250);
                    break;
                case "C":
                    condition = this.PowerUsage < 1251 || (this.PowerUsage >= 1251 && this.powerUsage <= 1500);
                    break;
                case "D":
                    condition = this.PowerUsage < 1500 || (this.PowerUsage >= 1501 && this.PowerUsage <= 2000);
                    break;
                case "E":
                    condition = this.PowerUsage > 2000 || this.PowerUsage < 2000;
                    break;
                default:
                    throw new ArgumentException(Constants.INCORRECTRATING);
            }

            if (condition)
            {
                return (int)TestScore.Success;
            }

            return (int)TestScore.Fail;
        }

        public override string ToString()
        {
            string print = base.ToString();

            print += "Required energy efficiency rating: " + this.EnergyEfficiencyRating 
                + "\r\n" 
                + "Power Usage(KW / h): " + this.PowerUsage 
                + "\r\n";

            print += "====================";

            return print;
        }
    }
}

namespace AirConditionerTestingSystem.Models
{
    using System;
    using AirConditionerTestingSystem.Utilities;

    public class PlaneAirConditioner : AirConditioner
    {
        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.VolumeCovered = volumeCoverage;
            this.ElectricityUsed = Convert.ToInt32(electricityUsed);
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NONPOSITIVE, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            double planeElectr = this.ElectricityUsed / sqrtVolume;
            if (planeElectr < Constants.MinPlaneElectricity)
            {
                // return 1;
                return (int)TestScore.Success;
            }

            return (int)TestScore.Fail;
        }

        public override string ToString()
        {
            string print = base.ToString();
            print += "Volume Covered: " + this.VolumeCovered 
                + "\r\n" 
                + "Electricity Used: " + this.ElectricityUsed 
                + "\r\n";

            print += "====================";

            return print;
        }
    }
}

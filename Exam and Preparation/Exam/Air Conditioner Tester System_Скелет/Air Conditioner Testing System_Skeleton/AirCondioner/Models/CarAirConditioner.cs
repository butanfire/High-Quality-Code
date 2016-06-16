namespace AirConditionerTestingSystem.Models
{
    using System;
    using AirConditionerTestingSystem.Utilities;

    public class CarAirConditioner : AirConditioner
    {
        public CarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.VolumeCovered = volumeCoverage;
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            if (sqrtVolume >= 3)
            {
                return (int)TestScore.Success;
            }

            return (int)TestScore.Fail;
        }

        public override string ToString()
        {
            string print = base.ToString();
            print += "Volume Covered: " + this.VolumeCovered
            + "\r\n";

            print += "====================";

            return print;
        }
    }
}

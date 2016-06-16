namespace AirConditionerTestingSystem.Models
{
    using System;
    using AirConditionerTestingSystem.Utilities;

    public abstract class AirConditioner
    {
        private string model;

        private string manufacturer;

        private int volumeCovered;

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.INCORRECTPROPERTYLENGTH, "Model", 2));
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.INCORRECTPROPERTYLENGTH, "Manufacturer", 4));
                }

                this.manufacturer = value;
            }
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NONPOSITIVE, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public abstract int Test();

        public override string ToString()
        {
            string print = "Air Conditioner"
                + "\r\n"
                + "===================="
                + "\r\n"
                + "Manufacturer: " + this.Manufacturer
                + "\r\n"
                + "Model: " + this.Model
                + "\r\n";

            return print;
        }
    }
}

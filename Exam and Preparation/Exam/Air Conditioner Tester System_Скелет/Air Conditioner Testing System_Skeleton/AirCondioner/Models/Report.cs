namespace AirConditionerTestingSystem.Models
{
    using System;
    using AirConditionerTestingSystem.Utilities;

    public class Report
    {
        public Report(string manufacturer, string model, int mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public int Mark { get; private set; }

        public override string ToString()
        {
            string result = string.Empty;
            MarkResult markResult = (MarkResult)Enum.Parse(typeof(MarkResult), this.Mark.ToString());

            result += "Report"
                + "\r\n" + "===================="
                + "\r\n"
                + "Manufacturer: " + this.Manufacturer
                + "\r\n"
                + "Model: " + this.Model
                + "\r\n"
                + "Mark: " + markResult
                + "\r\n" + "====================";

            return result;
        }
    }
}

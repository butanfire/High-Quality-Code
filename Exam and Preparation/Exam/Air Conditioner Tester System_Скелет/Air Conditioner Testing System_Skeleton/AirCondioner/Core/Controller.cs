namespace AirConditionerTestingSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AirConditionerTestingSystem.Data;
    using AirConditionerTestingSystem.Interfaces;
    using AirConditionerTestingSystem.Models;
    using AirConditionerTestingSystem.Utilities;

    public class Controller
    {
        private Database database;
        private IWriter writer;

        public Controller(Database data, IWriter writer)
        {
            this.database = data;
            this.writer = writer;
        }

        public void ParseCommands(CommandManager commands)
        {
            var commandArgs = commands;

            switch (commandArgs.Name)
            {
                case "RegisterStationaryAirConditioner":
                    this.ValidateParametersCount(commandArgs, 4);
                    this.writer.WriteLine(this.RegisterStationaryAirConditioner(
                        commandArgs.Parameters[0],
                        commandArgs.Parameters[1],
                        commandArgs.Parameters[2],
                        int.Parse(commandArgs.Parameters[3])));
                    break;
                case "RegisterCarAirConditioner":
                    this.ValidateParametersCount(commandArgs, 3);
                    this.writer.WriteLine(this.RegisterCarAirConditioner(
                        commandArgs.Parameters[0],
                        commandArgs.Parameters[1],
                        int.Parse(commandArgs.Parameters[2])));
                    break;
                case "RegisterPlaneAirConditioner":
                    this.ValidateParametersCount(commandArgs, 4);
                    this.writer.WriteLine(this.RegisterPlaneAirConditioner(
                        commandArgs.Parameters[0],
                        commandArgs.Parameters[1],
                        int.Parse(commandArgs.Parameters[2]),
                        commandArgs.Parameters[3]));
                    break;
                case "TestAirConditioner":
                    this.ValidateParametersCount(commandArgs, 2);
                    this.writer.WriteLine(this.TestAirConditioner(
                        commandArgs.Parameters[0],
                        commandArgs.Parameters[1]));
                    break;
                case "FindAirConditioner":
                    this.ValidateParametersCount(commandArgs, 2);
                    this.writer.WriteLine(this.FindAirConditioner(
                        commandArgs.Parameters[0],
                        commandArgs.Parameters[1]));
                    break;
                case "FindReport":
                    this.ValidateParametersCount(commandArgs, 2);
                    this.writer.WriteLine(this.FindReport(
                        commandArgs.Parameters[0],
                        commandArgs.Parameters[1]));
                    break;

                case "FindAllReportsByManufacturer":
                    this.ValidateParametersCount(commandArgs, 1);
                    this.writer.WriteLine(this.FindAllReportsByManufacturer(commandArgs.Parameters[0]));
                    break;
                case "Status":
                    this.ValidateParametersCount(commandArgs, 0);
                    this.writer.WriteLine(this.Status());
                    break;
                default:
                    throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }
        }

        /// <summary>
        /// Returns a percentage number of the existing AirConditioners tested.
        /// </summary>
        /// <returns>Percentage of the AirConditioners tested.</returns>
        public string Status()
        {
            double percent = 0;

            int reports = this.database.GetReportsCount();
            double airConditioners = this.database.GetAirConditionersCount();

            if (reports <= 0 || airConditioners <= 0)
            {
                percent = 0;
            }
            else
            {
                percent = reports / airConditioners;
                percent = percent * 100;
            }

            return string.Format(Constants.STATUS, percent);
        }

        public void ValidateParametersCount(CommandManager commandManager, int count)
        {
            if (commandManager.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }
        }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            AirConditioner airConditioner = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);

            this.database.AddAirConditioner(airConditioner);

            return string.Format(Constants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            AirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);

            this.database.AddAirConditioner(airConditioner);

            return string.Format(Constants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        /// <summary>
        /// Function for creating a new Plane and additing it to the db.
        /// </summary>
        /// <param name="manufacturer">Manufacturer name</param>
        /// <param name="model">Model name</param>
        /// <param name="volumeCoverage">Volume Coverage</param>
        /// <param name="electricityUsed">Electricity used</param>
        /// <returns>A new PlaneAirCOnditioner object</returns>
        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            AirConditioner airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);

            this.database.AddAirConditioner(airConditioner);

            return string.Format(Constants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.database.GetAirConditioner(manufacturer, model);
            ////Bug
            ////airConditioner.EnergyRating += 5;
            var mark = airConditioner.Test();

            this.database.AddReport(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));

            return string.Format(Constants.TEST, model, manufacturer);
        }

        /// <summary>
        /// Function for fetching an Air Conditioner by manufacturer and model from the db.
        /// </summary>
        /// <param name="manufacturer">Manufacturer name</param>
        /// <param name="model">Model name</param>
        /// <returns>The AirCondtioner to string if found, otherwise an exception is thrown.</returns>
        public string FindAirConditioner(string manufacturer, string model)
        {
            return this.database.GetAirConditioner(manufacturer, model).ToString();
        }

        public string FindReport(string manufacturer, string model)
        {
            return this.database.GetReport(manufacturer, model).ToString();
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            List<Report> reports = this.database.GetReportsByManufacturer(manufacturer);

            if (reports.Count == 0)
            {
                return Constants.NOREPORTS;
            }

            reports = reports.OrderBy(x => x.Model).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }
    }
}

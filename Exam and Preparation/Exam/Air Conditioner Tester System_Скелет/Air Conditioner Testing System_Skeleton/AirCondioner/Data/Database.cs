using System.Runtime.CompilerServices;
using AirConditionerTestingSystem.Exceptions;
using AirConditionerTestingSystem.Utilities;

namespace AirConditionerTestingSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using AirConditionerTestingSystem.Models;

    public class Database
    {
        private Dictionary<string, AirConditioner> airConditionerDict;
        private HashSet<Report> reportsList;
        private Dictionary<string, List<Report>> reportDict;

        public int ReportCount { get; set; }
        public int AirConditionerCount { get; set; }

        public Database()
        {
            this.airConditionerDict = new Dictionary<string, AirConditioner>();
            this.reportsList = new HashSet<Report>();
            this.reportDict = new Dictionary<string, List<Report>>();
        }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            var key = airConditioner.Model + airConditioner.Manufacturer;
            if (this.airConditionerDict.ContainsKey(key))
            {
                throw new DuplicateEntryException(Constants.DUPLICATE);
            }
            this.airConditionerDict.Add(key, airConditioner);
            this.AirConditionerCount++;
        }

        public AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            ////Possible BottleNeck? return firstOrDefault only
            var key = model + manufacturer;
            if (!this.airConditionerDict.ContainsKey(key))
            {
                throw new DuplicateEntryException(Constants.NONEXIST);
            }
            return this.airConditionerDict[key];
            //return this.airConditionerList.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int GetAirConditionersCount()
        {
            return this.AirConditionerCount;
        }

        public void AddReport(Report report)
        {
            
            if (!this.reportDict.ContainsKey(report.Manufacturer))
            {
                this.reportDict.Add(report.Manufacturer, new List<Report>());
                this.reportDict[report.Manufacturer].Add(report);
                this.ReportCount++;
            }
            else
            {
                if (this.reportDict[report.Manufacturer].Exists(s => s.Model == report.Model))
                {
                    throw new DuplicateEntryException(Constants.DUPLICATE);
                }

                this.reportDict[report.Manufacturer].Add(report);
            }
        }

        public Report GetReport(string manufacturer, string model)
        {
            if (!this.reportDict.ContainsKey(manufacturer))
            {
                throw new NonExistantEntryException(Constants.NONEXIST);
            }
            
            return reportDict[manufacturer].First(x => x.Model == model);
        }

        public int GetReportsCount()
        {
            return this.ReportCount;
        }

        public List<Report> GetReportsByManufacturer(string manufacturer)
        {
            if (!this.reportDict.ContainsKey(manufacturer))
            {
                return new List<Report>();
            }

            return this.reportDict[manufacturer];
        }
    }
}

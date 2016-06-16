using System.Linq;
using System.Text;
using TheatreApp.Interfaces;

namespace TheatreApp
{
    public class PerformanceCommandManager : IGetDB
    {
        public PerformanceCommandManager(IPerformanceDatabase someDB)
        {
            this.GetDB = someDB;
        }

        public IPerformanceDatabase GetDB { get; set; }

        public string ExecutePrintAllPerformancesCommand()
        {
            var performances = this.GetDB.ListAllPerformances().ToList();
            string temp = string.Empty;

            if (performances.Any())
            {
                var sb = new StringBuilder();
                for (int i = 0; i < performances.Count; i++)
                {
                    if (i < performances.Count - 1)
                    {
                        temp = performances[i].ToString();
                        sb.Append(temp + ", ");
                    }
                    else
                    {
                        temp = performances[i].ToString();
                        sb.Append(temp);
                    }
                }

                return sb.ToString();
            }

            return "No performances";
        }
    }
}

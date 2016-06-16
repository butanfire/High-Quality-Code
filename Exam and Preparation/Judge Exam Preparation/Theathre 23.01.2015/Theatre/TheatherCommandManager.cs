using System.Linq;
using TheatreApp.Interfaces;

namespace TheatreApp
{
    public class TheatherCommandManager : IGetDB
    {
        public TheatherCommandManager(IPerformanceDatabase someDB)
        {
            this.GetDB = someDB;
        }

        public IPerformanceDatabase GetDB { get; set; }

        public string ExecuteAddTheatreCommand(string[] parameters)
        {
            this.GetDB.AddTheatre(parameters[0]);
            return "Theatre added";
        }

        public string ExecutePrintAllTheatresCommand()
        {
            if (this.GetDB.ListTheatres().Any())
            {
                return string.Join(", ", this.GetDB.ListTheatres());
            }

            return "No theatres";
        }
    }
}

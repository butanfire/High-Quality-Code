namespace BoatRacingSimulator.Database
{
    using Interfaces;
    using Models;    
    using Models.Engines;

    public class BoatSimulatorDatabase
    {
        public BoatSimulatorDatabase()
        {
            Boats = new Repository<MotorBoat>();
            Engines = new Repository<Engines>();
        }

        public IRepository<MotorBoat> Boats { get; set; }

        public IRepository<Engines> Engines { get; private set; }
    }
}

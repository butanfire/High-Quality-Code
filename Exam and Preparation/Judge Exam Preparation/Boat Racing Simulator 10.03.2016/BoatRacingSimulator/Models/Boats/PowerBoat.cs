namespace BoatRacingSimulator.Models.Boats
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Engines;

    public class PowerBoat : MotorBoat
    {
        public PowerBoat(string model, int weight) : base(model, weight)
        {
        }

        public PowerBoat(string model, int weigth, IList<JetEngine> jetEngines, IList<SterndriveEngine> sterndriveEngines) : this(model, weigth)
        {
            JetEngines = jetEngines;
            SterndriveEngines = sterndriveEngines;
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var jet = JetEngines.Sum(x => x.Output);
            var stern = SterndriveEngines.Sum(x => x.Output);
            var speed = jet + stern - Weight + (race.OceanCurrentSpeed / 5d);
            return speed;
        }
    }
}

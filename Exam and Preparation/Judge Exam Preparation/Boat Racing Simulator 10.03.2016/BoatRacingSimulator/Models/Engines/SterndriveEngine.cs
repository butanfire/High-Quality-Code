namespace BoatRacingSimulator.Models.Engines
{
    public class SterndriveEngine : Engines
    {
        public SterndriveEngine(string model, int horsepower, int displacement)
        {
            Model = model;
            Horsepower = horsepower;
            Displacement = displacement;
            Output = (Horsepower * 7) + Displacement;
        }
    }
}

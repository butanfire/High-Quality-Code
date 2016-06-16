namespace BoatRacingSimulator.Models.Engines
{
    public class JetEngine : Engines
    {
        private const int JetEngineModifier = 5;
          
        public JetEngine(string model, int horsepower, int displacement)
        {
            Model = model;
            Horsepower = horsepower;
            Displacement = displacement;
            Output = (Horsepower * 5) + Displacement;
        }
    }
}

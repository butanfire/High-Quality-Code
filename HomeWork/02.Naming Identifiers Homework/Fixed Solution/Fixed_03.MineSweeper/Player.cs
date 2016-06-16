namespace MineSweeper
{
    public class Player
    {
        public Player(string name, int points = 0)
        {
            Name = name;
            Points = points;
        }

        public string Name { get; set; }

        public int Points { get; set; }
    }
}

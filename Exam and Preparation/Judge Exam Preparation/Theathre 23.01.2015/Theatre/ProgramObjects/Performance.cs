using System;

namespace TheatreApp.ProgramObjects
{
    public class Performance : IComparable<Performance>
    {
        public Performance(string name, string theathre, DateTime startTime, TimeSpan duration, decimal price)
        {
            this.Name = name;
            this.Theathre = theathre;
            this.StartTime = startTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string Name { get; private set; }

        public string Theathre { get; private set; }

        public DateTime StartTime { get; private set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; private set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            return this.StartTime.CompareTo(otherPerformance.StartTime);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", this.Name, this.Theathre, this.StartTime.ToString("dd.MM.yyyy HH:mm"));
        }
    }
}

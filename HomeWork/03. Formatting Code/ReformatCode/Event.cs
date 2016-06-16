namespace ReformatCode
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        public DateTime date;
        public string title;
        public string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;

            int byDate = date.CompareTo(other.date);
            int byTitle = title.CompareTo(other.title);

            var byLocation = location.CompareTo(other.location);
            if (byDate == 0)
            {
                return byTitle == 0 ? byLocation : byTitle;
            }

            return byDate;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + title);

            if (!string.IsNullOrEmpty(location))
            {
                toString.Append(" | " + location);
            }

            return toString.ToString();
        }
    }
}

using System;

namespace TheatreApp.Exceptions
{
    public class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException(string msg) : base(msg)
        {
        }
    }
}

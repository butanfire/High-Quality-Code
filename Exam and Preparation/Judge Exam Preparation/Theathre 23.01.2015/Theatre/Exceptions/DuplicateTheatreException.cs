using System;

namespace TheatreApp.Exceptions
{
    public class DuplicateTheatreException : Exception
    {
        public DuplicateTheatreException(string msg) : base(msg)
        {
        }
    }
}

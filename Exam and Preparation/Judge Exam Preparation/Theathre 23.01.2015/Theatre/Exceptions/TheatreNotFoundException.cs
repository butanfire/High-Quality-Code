using System;

namespace TheatreApp.Exceptions
{
    public class TheatreNotFoundException : Exception
    {
        public TheatreNotFoundException(string msg) : base(msg)
        {
        }
    }
}
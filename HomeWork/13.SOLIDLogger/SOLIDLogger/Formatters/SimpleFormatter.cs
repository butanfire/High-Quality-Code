namespace SOLIDLogger.Formatters
{
    using System;
    using Interfaces;

    /// <summary>
    /// Class for Simple Formatting for messages.
    /// </summary>
    public class SimpleFormatter : IFormatter
    {
        /// <summary>
        /// Simple format uses one-line logging.
        /// </summary>
        /// <param name="msg">The message for logging.</param>
        /// <param name="level">The severity of the message.</param>
        /// <param name="date">The date/time of the message.</param>
        /// <returns>The formatted string in Simple format.</returns>
        public string Format(string msg, ReportLevel level, DateTime date)
        {
            return string.Format("{0} - {1} - {2}", date, level, msg);
        }
    }
}

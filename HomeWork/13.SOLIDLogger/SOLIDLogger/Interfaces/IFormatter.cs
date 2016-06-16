namespace SOLIDLogger.Interfaces
{
    using System;

    /// <summary>
    /// Abstraction for the Formatting.
    /// To support different formats, which are used by the Appenders.
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Function for the different Formats - Simple/XML/etc.
        /// </summary>
        /// <param name="msg">The message for logging.</param>
        /// <param name="level">The severity of the message.</param>
        /// <param name="date">The date/time of the message.</param>
        /// <returns>Formatted string in the specified format.</returns>
        string Format(string msg, ReportLevel level, DateTime date);
    }
}

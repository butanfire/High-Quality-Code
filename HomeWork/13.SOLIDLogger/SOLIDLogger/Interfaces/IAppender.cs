namespace SOLIDLogger.Interfaces
{
    using System;

    /// <summary>
    /// Abstraction for the Appender.
    /// To support different Appenders.
    /// </summary>
    public interface IAppender
    {
        /// <summary>
        /// Gets or sets the Formatter to be used for the Appender..
        /// </summary>
        IFormatter Formatter { get; set; }

        /// <summary>
        /// Append messages to the respective Appender - File/Console/etc.
        /// </summary>
        /// <param name="msg">The message for logging.</param>
        /// <param name="level">The severity of the message.</param>
        /// <param name="date">The date/time of the message.</param>
        void Append(string message, ReportLevel level, DateTime date);
    }
}

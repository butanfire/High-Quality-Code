namespace SOLIDLogger.Appenders
{
    using System;
    using Interfaces;

    /// <summary>
    /// Appender for Console messages.
    /// </summary>
    public class ConsoleAppender : Appender
    {
        /// <summary>
        /// Initializes a new instance of the for the Console appender in a specific format.
        /// </summary>
        /// <param name="formatter">The format for logging.</param>
        public ConsoleAppender(IFormatter formatter) : base(formatter)
        {
        }

        /// <summary>
        /// Append a message to the console.
        /// </summary>
        /// <param name="message">The message logged.</param>
        /// <param name="level">The severity of the message.</param>
        /// <param name="date">The date/time of the message.</param>
        public override void Append(string message, ReportLevel level, DateTime date)
        {
            string output = this.Formatter.Format(message, level, date);
            Console.WriteLine(output);
        }
    }
}

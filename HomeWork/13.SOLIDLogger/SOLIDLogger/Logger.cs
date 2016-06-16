namespace SOLIDLogger
{
    using System;
    using Interfaces;

    /// <summary>
    /// Class for the Logger, who will call the append operations.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Initializes a new instance of the Logger class and choose the appender - Console/File/etc.
        /// </summary>
        /// <param name="appender">The Appender to be used.</param>
        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }

        /// <summary>
        /// Gets / Sets the Appender - it can be changed.
        /// </summary>
        public IAppender Appender { get; set; }

        /// <summary>
        /// Function for logging Info messages.
        /// </summary>
        /// <param name="msg">The message to be logged.</param>
        public void Info(string msg)
        {
            this.Log(msg, ReportLevel.Info);
        }

        /// <summary>
        ///  Function for logging Warning messages.
        /// </summary>
        /// <param name="msg">The message to be logged.</param>
        public void Warn(string msg)
        {
            this.Log(msg, ReportLevel.Warn);
        }

        /// <summary>
        ///  Function for logging Error messages.
        /// </summary>
        /// <param name="msg">The message to be logged.</param>
        public void Error(string msg)
        {
            this.Log(msg, ReportLevel.Error);
        }

        /// <summary>
        ///  Function for logging Critical messages. 
        /// </summary>
        /// <param name="msg">The message to be logged.</param>
        public void Critical(string msg)
        {
            this.Log(msg, ReportLevel.Critical);
        }

        /// <summary>
        ///  Function for logging Fatal messages.
        /// </summary>
        /// <param name="msg">The message to be logged.</param>
        public void Fatal(string msg)
        {
            this.Log(msg, ReportLevel.Fatal);
        }

        /// <summary>
        /// Primary function for logging Messages.
        /// </summary>
        /// <param name="msg">Message to be Appended.</param>
        /// <param name="level">Message level of the message.</param>
        private void Log(string msg, ReportLevel level)
        {
            var date = DateTime.Now;
            this.Appender.Append(msg, level, date);
        }
    }
}

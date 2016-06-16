namespace SOLIDLogger.Appenders
{
    using System;
    using Interfaces;

    /// <summary>
    /// Abstract class for all kind of Appenders.
    /// So they can inherit a specific format, which can also be changed.
    /// </summary>
    public abstract class Appender : IAppender
    {
        /// <summary>
        /// Abstraction for the formatter.
        /// </summary>
        private IFormatter formatter;

        /// <summary>
        /// Initializes a new instance of the Appender for the formatter to Simple or XML (or any new ones added)
        /// </summary>
        /// <param name="formatter">The format used</param>
        protected Appender(IFormatter formatter)
        {
            this.Formatter = formatter;
        }

        /// <summary>
        /// Get or sets for the Formatter
        /// </summary>
        public IFormatter Formatter
        {
            get
            {
                return this.formatter;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        "Formatter cannot be null");
                }

                this.formatter = value;
            }
        }

        /// <summary>
        /// Appender to be used by the (child) appenders - Console/File/etc.
        /// </summary>
        /// <param name="message">The message to be printed.</param>
        /// <param name="level">The level of logging used.</param>
        /// <param name="date">The date/time of the message.</param>
        public abstract void Append(string message, ReportLevel level, DateTime date);
    }
}

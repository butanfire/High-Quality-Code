namespace SOLIDLogger.Appenders
{
    using System;
    using System.IO;
    using Interfaces;

    /// <summary>
    /// Appender for Files
    /// </summary>
    public class FileAppender : Appender
    {
        /// <summary>
        /// Variable for writing messages in the files.
        /// </summary>
        private StreamWriter writer;

        /// <summary>
        /// Initializes a new instance of the FileAppender to use a format and file.
        /// </summary>
        /// <param name="path">The path of the file for logging.</param>
        /// <param name="formatter">The format of the messages.</param>
        public FileAppender(string path, IFormatter formatter)
            : base(formatter)
        {
            this.Path = path;
            this.writer = new StreamWriter(this.Path, true);
        }

        /// <summary>
        /// Gets or sets the file path where to log the messages.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Append a message to the console.
        /// </summary>
        /// <param name="message">The message logged.</param>
        /// <param name="level">The severity of the message.</param>
        /// <param name="date">The date/time of the message.</param>
        public override void Append(string message, ReportLevel level, DateTime date)
        {
            string output = this.Formatter.Format(message, level, date);
            this.writer.WriteLine(output);
        }

        /// <summary>
        /// Closing the writer stream for writing in the file.
        /// </summary>
        public void Close()
        {
            this.writer.Close();
        }
    }
}

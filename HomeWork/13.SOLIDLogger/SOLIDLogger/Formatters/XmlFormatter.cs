namespace SOLIDLogger.Formatters
{
    using System;
    using System.Text;
    using Interfaces;

    /// <summary>
    /// Class for XML formatting messages.
    /// </summary>
    public class XmlFormatter : IFormatter
    {
        /// <summary>
        /// XML Format uses xml format logging.
        /// </summary>
        /// <param name="msg">The message for logging.</param>
        /// <param name="level">The severity of the message.</param>
        /// <param name="date">The date/time of the message.</param>
        /// <returns>The string formatted in XML. (to be appended)</returns>
        public string Format(string msg, ReportLevel level, DateTime date)
        {
            var output = new StringBuilder();
            output.AppendLine("<log>");
            output.AppendLine("<message>" + msg + "</message>");
            output.AppendLine("<level>" + level + "</level>");
            output.AppendLine("<date>" + date + "</date>");
            output.AppendLine("</log>");

            return output.ToString();
        }
    }
}

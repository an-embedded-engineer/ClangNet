using System.Collections.Generic;

namespace ClangNet
{
    /// <summary>
    /// Log Manager
    /// </summary>
    public class LogManager : ILogger
    {
        /// <summary>
        /// Logger Interface List
        /// </summary>
        private List<ILogger> Loggers { get; set; } = new List<ILogger>();

        /// <summary>
        /// Constructor
        /// </summary>
        public LogManager()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loggers">Logger Interface List</param>
        public LogManager(params ILogger[] loggers)
        {
            this.Loggers.AddRange(loggers);
        }

        /// <summary>
        /// Add Logger
        /// </summary>
        /// <param name="logger">Logger Interface</param>
        public void Add(ILogger logger)
        {
            this.Loggers.Add(logger);
        }

        /// <summary>
        /// Add Loggers
        /// </summary>
        /// <param name="loggers">Logger Interface List</param>
        public void Add(IEnumerable<ILogger> loggers)
        {
            this.Loggers.AddRange(loggers);
        }

        /// <summary>
        /// Dispose Logger
        /// </summary>
        public void Dispose()
        {
            this.Loggers.ForEach(logger => logger.Dispose());
        }

        /// <summary>
        /// Send Verbatim Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public void Verb(string message, bool new_line)
        {
            this.Loggers.ForEach(logger => logger.Verb(message, new_line));
        }

        /// <summary>
        /// Send Information Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public void Info(string message, bool new_line)
        {
            this.Loggers.ForEach(logger => logger.Info(message, new_line));
        }

        /// <summary>
        /// Send Warning Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public void Warn(string message, bool new_line)
        {
            this.Loggers.ForEach(logger => logger.Warn(message, new_line));
        }

        /// <summary>
        /// Send Error Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public void Error(string message, bool new_line)
        {
            this.Loggers.ForEach(logger => logger.Error(message, new_line));
        }
    }
}

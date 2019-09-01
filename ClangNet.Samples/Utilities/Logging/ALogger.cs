namespace ClangNet
{
    /// <summary>
    /// Abstract Logger
    /// </summary>
    public abstract class ALogger : ILogger
    {
        /// <summary>
        /// Dispose Logger
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Write Log Message
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        protected abstract void WriteMessage(string message, bool new_line);

        /// <summary>
        /// Send Verbatim Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public void Verb(string message, bool new_line)
        {
            this.WriteMessage(message, new_line);
        }

        /// <summary>
        /// Send Information Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public void Info(string message, bool new_line)
        {
            this.WriteMessage($"[INFO]{message}", new_line);
        }

        /// <summary>
        /// Send Warning Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public void Warn(string message, bool new_line)
        {
            this.WriteMessage($"[WARN]{message}", new_line);
        }

        /// <summary>
        /// Send Error Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public void Error(string message, bool new_line)
        {
            this.WriteMessage($"[ERROR]{message}", new_line);
        }
    }
}

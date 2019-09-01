using System;
using System.Linq;

namespace ClangNet
{
    /// <summary>
    /// Logger Interface
    /// </summary>
    public interface ILogger : IDisposable
    {
        /// <summary>
        /// Send Verbatim Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        void Verb(string message, bool new_line);

        /// <summary>
        /// Send Information Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        void Info(string message, bool new_line);

        /// <summary>
        /// Send Warning Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        void Warn(string message, bool new_line);

        /// <summary>
        /// Send Error Log
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        void Error(string message, bool new_line);
    }
}

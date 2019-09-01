using System;

namespace ClangNet
{
    /// <summary>
    /// Console Logger
    /// </summary>
    public class ConsoleLogger : ALogger
    {
        /// <summary>
        /// Dispose Logger
        /// </summary>
        public override void Dispose()
        {
            /* Nothing to do */
        }

        /// <summary>
        /// Write Log Message
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        protected override void WriteMessage(string message, bool new_line)
        {
            if (new_line)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }
        }
    }

}

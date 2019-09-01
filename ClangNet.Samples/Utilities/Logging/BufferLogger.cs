using System.Text;

namespace ClangNet
{
    /// <summary>
    /// Buffer Logger
    /// </summary>
    public class BufferLogger : ALogger
    {
        /// <summary>
        /// String Buffer
        /// </summary>
        public StringBuilder Buffer { get; } = new StringBuilder();

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
                this.Buffer.Append(message);
            }
            else
            {
                this.Buffer.AppendLine(message);
            }
        }
    }
}

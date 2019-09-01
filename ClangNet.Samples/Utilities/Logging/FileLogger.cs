using System.IO;
using System.Text;

namespace ClangNet
{
    /// <summary>
    /// File Logger
    /// </summary>
    public class FileLogger : ALogger
    {
        /// <summary>
        /// Stream Writer
        /// </summary>
        private StreamWriter Writer { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">File Name</param>
        public FileLogger(string filename)
        {
            this.Writer = new StreamWriter(filename, false, Encoding.UTF8);
        }

        /// <summary>
        /// Dispose Logger
        /// </summary>
        public override void Dispose()
        {
            this.Writer.Dispose();
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
                this.Writer.WriteLine(message);
            }
            else
            {
                this.Writer.Write(message);
            }
        }
    }
}

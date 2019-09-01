using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Clang Service Exception
    /// </summary>
    public class ClangServiceException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error Message</param>
        public ClangServiceException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        public ClangServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <param name="inner_exception">Inner Exception</param>
        public ClangServiceException(string message, Exception inner_exception) : base(message, inner_exception)
        {
        }
    }
}

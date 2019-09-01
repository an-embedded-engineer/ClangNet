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
    /// Managed Abstract Clang Location
    /// </summary>
    public abstract class ClangLocation
    {
        /// <summary>
        /// Line
        /// </summary>
        public uint Line { get; }

        /// <summary>
        /// Column
        /// </summary>
        public uint Column { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="line">Line</param>
        /// <param name="column">Column</param>
        protected ClangLocation(uint line, uint column)
        {
            this.Line = line;

            this.Column = column;
        }
    }
}

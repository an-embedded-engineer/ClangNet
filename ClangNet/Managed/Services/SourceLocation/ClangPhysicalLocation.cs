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
    /// Managed Clang Physical Location
    /// </summary>
    public class ClangPhysicalLocation : ClangLocation
    {
        /// <summary>
        /// Clang File
        /// </summary>
        public ClangFile File { get; }

        /// <summary>
        /// Offset
        /// </summary>
        public uint Offset { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <param name="line">Line</param>
        /// <param name="column">Column</param>
        /// <param name="offset">Offset</param>
        public ClangPhysicalLocation(ClangFile file, uint line, uint column, uint offset)
            : base(line, column)
        {
            this.File = file;

            this.Offset = offset;
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>Physical Location</returns>
        public override string ToString()
        {
            if (this.Line > 0)
            {
                return $"{this.File} [{this.Line},{this.Column}]";
            }
            else
            {
                return $"{this.File} [Offset:{this.Offset}]";
            }
        }
    }
}

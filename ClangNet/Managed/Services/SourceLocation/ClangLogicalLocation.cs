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
    /// Managed Clang Logical Location
    /// </summary>
    public class ClangLogicalLocation : ClangLocation
    {
        /// <summary>
        /// File Name
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="file_name">File Name</param>
        /// <param name="line">Line</param>
        /// <param name="column">Column</param>
        public ClangLogicalLocation(string file_name, uint line, uint column)
            : base(line, column)
        {
            this.FileName = file_name;
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>Logical Location</returns>
        public override string ToString()
        {
            return $"{this.FileName} [{this.Line},{this.Column}]";
        }
    }
}

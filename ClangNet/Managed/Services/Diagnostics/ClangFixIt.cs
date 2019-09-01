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
    /// Managed Clang Fix It
    /// </summary>
    public struct ClangFixIt
    {
        /// <summary>
        /// Replacement Clang Source Range
        /// </summary>
        public ClangSourceRange ReplacementRange { get; private set; }

        /// <summary>
        /// Replacement Text
        /// </summary>
        public string ReplacementText { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="replacement_range">Replacement Clang Source Range</param>
        /// <param name="replacement_text">Replacement Text</param>
        public ClangFixIt(ClangSourceRange replacement_range, string replacement_text)
        {
            this.ReplacementRange = replacement_range;
            this.ReplacementText = replacement_text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // CXSourceRange*
    using CXSourceRangePtr = IntPtr;

    /// <summary>
    /// Native Clang Source Range List
    /// </summary>
    /// <remarks>
    /// Identifies an array of ranges.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXSourceRangeList
    {
        /// <summary>
        /// Source Range Count
        /// </summary>
        /// <remarks>
        /// The number of ranges in the <c>Ranges</c> array.
        /// </remarks>
        public readonly uint Count;

        /// <summary>
        /// Clang Source Range Array Pointer
        /// </summary>
        /// <remarks>
        /// An array of <c>CXSourceRange</c>
        /// </remarks>
        public readonly CXSourceRangePtr Ranges;
    }
}

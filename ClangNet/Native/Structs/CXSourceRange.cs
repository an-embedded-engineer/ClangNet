using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Native Clang Source Range
    /// </summary>
    /// <remarks>
    /// Identifies a half-open character range in the source code.
    ///
    /// Use <c>clang_getRangeStart()</c> and <c>clang_getRangeEnd()</c>
    /// to retrieve the starting and end locations from a source range, respectively.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXSourceRange
    {
        /// <summary>
        /// 1st Data of void* [2]
        /// </summary>
        public readonly VoidPtr PtrData1;

        /// <summary>
        /// 2nd Data of void* [2]
        /// </summary>
        public readonly VoidPtr PtrData2;

        /// <summary>
        /// Begin Int Data
        /// </summary>
        public readonly int BeginIntData;

        /// <summary>
        /// End Int Data
        /// </summary>
        public readonly int EndIntData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="begin">Begin Int Data</param>
        /// <param name="end">End Int Data</param>
        public CXSourceRange(int begin, int end)
        {
            PtrData1 = IntPtr.Zero;
            PtrData2 = IntPtr.Zero;
            BeginIntData = begin;
            EndIntData = end;
        }
    }
}

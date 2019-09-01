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
    /// Native Clang Source Location
    /// </summary>
    /// <remarks>
    /// Identifies a specific source location within a translation unit.
    ///
    /// Use <c>clang_getExpansionLocation()</c> or <c>clang_getSpellingLocation()</c>
    /// to map a source location to a particular file, line, and column.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXSourceLocation
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
        /// Int Data
        /// </summary>
        public readonly uint IntData;
    }
}

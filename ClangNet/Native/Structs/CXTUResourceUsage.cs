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

    // CXTUResourceUsageEntry*
    using CXTUResourceUsageEntryPtr = IntPtr;

    /// <summary>
    /// Native Clang Translation Unit Resource Usage
    /// </summary>
    /// <remarks>
    /// The memory usage of a CXTranslationUnit, broken into categories.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXTUResourceUsage
    {
        /// <summary>
        /// Pointer Data
        /// </summary>
        /// <remarks>
        /// Private data member, used for queries.
        /// </remarks>
        public readonly VoidPtr Data;

        /// <summary>
        /// Number of Resource Usage Entriy Array
        /// </summary>
        /// <remarks>
        /// The number of entries in the 'entries' array.
        /// </remarks>
        public readonly uint NumEntries;

        /// <summary>
        /// Clang Translation Unit Resource Usage Entry Array Pointer
        /// </summary>
        /// <remarks>
        /// An array of key-value pairs, representing the breakdown of memory usage.
        /// </remarks>
        public readonly CXTUResourceUsageEntryPtr Entries;
    }
}

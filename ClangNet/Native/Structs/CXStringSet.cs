using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // CXString*
    using CXStringPtr = IntPtr;

    /// <summary>
    /// Native Clang String Set
    /// </summary>
    /// <remarks>
    /// <c>CXString</c> collection.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXStringSet
    {
        /// <summary>
        /// Clang String Array Pointer
        /// </summary>
        internal readonly CXStringPtr Strings;

        /// <summary>
        /// String Count
        /// </summary>
        internal readonly uint Count;
    }
}

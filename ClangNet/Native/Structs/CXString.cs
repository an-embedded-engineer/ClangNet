using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Native Clang String
    /// </summary>
    /// <remarks>
    /// A character string.
    ///
    /// The <c>CXString</c> type is used to return strings from the interface when
    /// the ownership of that string might differ from one call to the next.
    /// Use <c>clang_getCString()</c> to retrieve the string data and, once finished
    /// with the string data, call <c>clang_disposeString()</c> to free the string.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXString
    {
        /// <summary>
        /// Data of void*
        /// </summary>
        internal readonly VoidPtr Data;

        /// <summary>
        /// Private Flags
        /// </summary>
        internal readonly uint PrivateFlags;
    }
}

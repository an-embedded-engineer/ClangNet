using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    /// <summary>
    /// Native Clang Index Container Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxContainerInfo
    {
        /// <summary>
        /// Clang Cursor
        /// </summary>
        public readonly CXCursor Cursor;
    }
}

using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    /// <summary>
    /// Native Clang Index Attribute Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxAttrInfo
    {
        /// <summary>
        /// Index Attribute Kind
        /// </summary>
        public readonly IndexAttributeKind Kind;

        /// <summary>
        /// Clang Cursor
        /// </summary>
        public readonly CXCursor Cursor;

        /// <summary>
        /// Clang Index Location
        /// </summary>
        public readonly CXIdxLoc Loc;
    }
}

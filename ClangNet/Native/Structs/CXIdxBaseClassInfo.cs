using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxEntityInfo*
    using ConstCXIdxEntityInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Base Class Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxBaseClassInfo
    {
        /// <summary>
        /// Base Clang Index Entity Info Pointer
        /// </summary>
        public readonly ConstCXIdxEntityInfoPtr Base;

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

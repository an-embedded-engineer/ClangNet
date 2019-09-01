using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxEntityInfo*
    using ConstCXIdxEntityInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Objective-C Protocol Reference Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxObjCProtocolRefInfo
    {
        /// <summary>
        /// Protocol Clang Index Entity Info Pointer
        /// </summary>
        public readonly ConstCXIdxEntityInfoPtr Protocol;

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

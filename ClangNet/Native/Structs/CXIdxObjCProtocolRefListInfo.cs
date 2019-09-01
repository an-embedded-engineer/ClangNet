using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxObjCProtocolRefInfo*
    using ConstCXIdxObjCProtocolRefInfoPtr = IntPtr;

    /// <summary>
    /// Clang Index Objective-C Protocol Reference List Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxObjCProtocolRefListInfo
    {
        /// <summary>
        /// Clang Index Objective-C Protocol Reference Info Array Pointer
        /// </summary>
        public readonly ConstCXIdxObjCProtocolRefInfoPtr Protocols;

        /// <summary>
        /// Number of Protocol Reference Info Array
        /// </summary>
        public readonly uint NumProtocols;
    }
}

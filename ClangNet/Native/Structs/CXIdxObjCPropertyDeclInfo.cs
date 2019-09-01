using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxDeclInfo*
    using ConstCXIdxDeclInfoPtr = IntPtr;

    // const CXIdxEntityInfo*
    using ConstCXIdxEntityInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Objective-C Property Declaration Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxObjCPropertyDeclInfo
    {
        /// <summary>
        /// Clang Index Declaration Info Pointer
        /// </summary>
        public readonly ConstCXIdxDeclInfoPtr DeclInfo;

        /// <summary>
        /// Getter Clang Index Entity Info Pointer
        /// </summary>
        public readonly ConstCXIdxEntityInfoPtr Getter;

        /// <summary>
        /// Setter Clang Index Entity Info Pointer
        /// </summary>
        public readonly ConstCXIdxEntityInfoPtr Setter;
    }
}

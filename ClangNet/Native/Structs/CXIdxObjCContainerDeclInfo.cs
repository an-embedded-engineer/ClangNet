using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxDeclInfoPtr*
    using ConstCXIdxDeclInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Objective-C Container Declaration Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxObjCContainerDeclInfo
    {
        /// <summary>
        /// Clang Index Declaration Info Pointer
        /// </summary>
        public readonly ConstCXIdxDeclInfoPtr DeclInfo;

        /// <summary>
        /// Index Objective-C Container Kind
        /// </summary>
        public readonly IndexObjCContainerKind Kind;
    }
}

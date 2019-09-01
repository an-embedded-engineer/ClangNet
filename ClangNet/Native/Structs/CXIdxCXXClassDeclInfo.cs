using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxDeclInfo*
    using ConstCXIdxDeclInfoPtr = IntPtr;

    // const CXIdxBaseClassInfo*
    using ConstCXIdxBaseClassInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index C++ Class Declaration Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxCXXClassDeclInfo
    {
        /// <summary>
        /// Clang Index Declaration Info Pointer
        /// </summary>
        public readonly ConstCXIdxDeclInfoPtr DeclInfo;

        /// <summary>
        /// Clang Index Base Class Info Array Pointer
        /// </summary>
        public readonly ConstCXIdxBaseClassInfoPtr Bases;

        /// <summary>
        /// Number of Base Class Info Array
        /// </summary>
        public readonly uint NumBases;
    }
}

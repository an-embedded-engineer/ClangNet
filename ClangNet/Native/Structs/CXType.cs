using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Native Clang Type
    /// </summary>
    /// <remarks>
    /// The type of an element in the abstract syntax tree.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXType
    {
        /// <summary>
        /// Type Kind
        /// </summary>
        public readonly TypeKind Kind;

        /// <summary>
        /// 1st Data of void* [2]
        /// </summary>
        public readonly VoidPtr Data1;

        /// <summary>
        /// 2nd Data of void* [2]
        /// </summary>
        public readonly VoidPtr Data2;
    }
}

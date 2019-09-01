using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Native Clang Token
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXToken
    {
        /// <summary>
        /// 1st Data of unsigned [4]
        /// </summary>
        public readonly uint int_data1;

        /// <summary>
        /// 2nd Data of unsigned [4]
        /// </summary>
        public readonly uint int_data2;

        /// <summary>
        /// 3rd Data of unsigned [4]
        /// </summary>
        public readonly uint int_data3;

        /// <summary>
        /// 4th Data of unsigned [4]
        /// </summary>
        public readonly uint int_data4;

        /// <summary>
        /// Pointer Data
        /// </summary>
        public readonly VoidPtr ptr_data;
    }
}

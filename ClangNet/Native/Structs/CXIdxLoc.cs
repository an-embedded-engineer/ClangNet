using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Location
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxLoc
    {
        /// <summary>
        /// 1st Data of void* [2]
        /// </summary>
        public readonly VoidPtr PtrData1;

        /// <summary>
        /// 2nd Data of void* [2]
        /// </summary>
        public readonly VoidPtr PtrData2;

        /// <summary>
        /// Int Data
        /// </summary>
        public readonly uint IntData;
    }
}

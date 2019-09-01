using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    /// <summary>
    /// Native Clang File Unique ID
    /// </summary>
    /// <remarks>
    /// Uniquely identifies a CXFile, that refers to the same underlying file,
    /// across an indexing session.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXFileUniqueID
    {
        /// <summary>
        /// 1st data of unsigned long long [3]
        /// </summary>
        public readonly ulong Data1;

        /// <summary>
        /// 2nd data of unsigned long long [3]
        /// </summary>
        public readonly ulong Data2;

        /// <summary>
        /// 3rd data of unsigned long long [3]
        /// </summary>
        public readonly ulong Data3;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data1">1st data</param>
        /// <param name="data2">2nd data</param>
        /// <param name="data3">3rd data</param>
        public CXFileUniqueID(ulong data1, ulong data2, ulong data3)
        {
            this.Data1 = data1;
            this.Data2 = data2;
            this.Data3 = data3;
        }
    }
}

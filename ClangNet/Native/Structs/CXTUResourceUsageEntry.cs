using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    /// <summary>
    /// Native Clang Translation Unit Resource Usage Entry
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXTUResourceUsageEntry
    {
        /// <summary>
        /// Resource Usage Kind
        /// </summary>
        /// <remarks>
        /// The memory usage category.
        /// </remarks>
        public readonly ResourceUsageKind Kind;

        /// <summary>
        /// Amount
        /// </summary>
        /// <remarks>
        /// Amount of resources used.
        ///
        /// The units will depend on the resource kind.
        /// </remarks>
        public readonly ulong Amount;
    }
}

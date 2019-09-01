using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // CXCompletionResult*
    using CXCompletionResultPtr = IntPtr;

    /// <summary>
    /// Native Clang Code Complete Results
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXCodeCompleteResults
    {
        /// <summary>
        /// Clang Completion Result Array Pointer
        /// </summary>
        public readonly CXCompletionResultPtr Results;

        /// <summary>
        /// Number of Completion Result Array
        /// </summary>
        public readonly uint NumResults;
    }
}

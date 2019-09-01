using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // void*
    using CXCompletionString = IntPtr;

    /// <summary>
    /// Native Clang Completion Result
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXCompletionResult
    {
        /// <summary>
        /// Cursor Kind
        /// </summary>
        public readonly CursorKind CursorKind;

        /// <summary>
        /// Clang Completion String
        /// </summary>
        public readonly CXCompletionString CompletionString;
    }
}

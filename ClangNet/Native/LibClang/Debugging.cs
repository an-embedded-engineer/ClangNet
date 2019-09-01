#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // const char*
    using ConstCharPtr = IntPtr;

    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Debugging
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Get Cursor Kind Spelling
        /// </summary>
        /// <param name="Kind">Cursor Kind</param>
        /// <returns>Cursor Kind Spelling</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getCursorKindSpelling(CursorKind Kind);

        /// <summary>
        /// Get Definition Spelling And Extent
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="start_buf">Start Buffer Pointer</param>
        /// <param name="end_buf">End Buffer Pointer</param>
        /// <param name="start_line">Start Line</param>
        /// <param name="start_column">Start Column</param>
        /// <param name="end_line">End Line</param>
        /// <param name="end_column">End Column</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_getDefinitionSpellingAndExtent(CXCursor cursor,
                                                                         out ConstCharPtr start_buf, out ConstCharPtr end_buf,
                                                                         out uint start_line, out uint start_column,
                                                                         out uint end_line, out uint end_column);

        /// <summary>
        /// Enable Stack Traces
        /// </summary>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_enableStackTraces();

        /// <summary>
        /// Execute Function On Thread
        /// </summary>
        /// <param name="fn">Function</param>
        /// <param name="user_data">User Data</param>
        /// <param name="stack_size">Stack Size</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_executeOnThread(Action<VoidPtr> fn, VoidPtr user_data, uint stack_size);
    }
}

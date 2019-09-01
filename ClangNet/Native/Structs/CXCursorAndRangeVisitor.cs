using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Native Clang Cursor And Range Visitor Handler
    /// </summary>
    /// <param name="context">Context</param>
    /// <param name="cursor">Clang Cursor</param>
    /// <param name="range">Clang Source Range</param>
    /// <returns>Visitor Result</returns>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate VisitorResult CXCursorAndRangeVisitorHandler(VoidPtr context, CXCursor cursor, CXSourceRange range);

    /// <summary>
    /// Native Clang Cursor And Range Visitor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXCursorAndRangeVisitor
    {
        /// <summary>
        /// Context
        /// </summary>
        public readonly VoidPtr Context;

        /// <summary>
        /// Clang Cursor And Range Visitor Handler
        /// </summary>
        public readonly CXCursorAndRangeVisitorHandler Visit;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="visit">Clang Cursor And Range Visitor Delegate</param>
        internal CXCursorAndRangeVisitor(CXCursorAndRangeVisitorHandler visit)
        {
            Context = IntPtr.Zero;
            Visit = visit;
        }
    }
}

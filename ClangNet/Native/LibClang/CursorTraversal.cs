#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // Opaque pointer representing client data that will be passed through
    // to various callbacks and visitors.
    // void*
    using CXClientData = IntPtr;

    /// <summary>
    /// Visitor invoked for each cursor found by a traversal.
    ///
    /// This visitor function will be invoked for each cursor found by
    /// <c>clang_visitCursorChildren()</c>.
    /// Its first argument is the cursor being visited,
    /// its second argument is the parent visitor for that cursor,
    /// and its third argument is the client data provided to
    /// <c>clang_visitCursorChildren()</c>.
    ///
    /// The visitor should return one of the <c>CXChildVisitResult</c>
    /// values to direct <c>clang_visitCursorChildren()</c>.
    /// </summary>
    /// <param name="cursor">Cursor</param>
    /// <param name="parent">Parent Cursor</param>
    /// <param name="client_data">Client Data</param>
    /// <returns>Child Visit Result</returns>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate ChildVisitResult CXCursorVisitor(CXCursor cursor, CXCursor parent, CXClientData client_data);

    /// <summary>
    /// Libclang P/Invoke : Cursor Traversal
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Visit the children of a particular cursor.
        ///
        /// This function visits all the direct children of the given cursor,
        /// invoking the given <paramref name="visitor"/> function with the cursors of each
        /// visited child.The traversal may be recursive, if the visitor returns
        /// <c>CXChildVisit_Recurse</c>. The traversal may also be ended prematurely, if
        /// the visitor returns <c>CXChildVisit_Break</c>.
        /// </summary>
        /// <param name="parent">
        /// the cursor whose child may be visited.All kinds of
        /// cursors can be visited, including invalid cursors (which, by
        /// definition, have no children).
        /// </param>
        /// <param name="visitor">
        /// the visitor function that will be invoked for each
        /// child of <paramref name="parent"/>.
        /// </param>
        /// <param name="client_data">
        /// pointer data supplied by the client, which will
        /// be passed to the visitor each time it is invoked.
        /// </param>
        /// <returns>
        /// a non-zero value if the traversal was terminated
        /// prematurely by the visitor returning <c>CXChildVisit_Break</c>.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ChildVisitResult clang_visitChildren(CXCursor parent, CXCursorVisitor visitor, CXClientData client_data);
    }
}

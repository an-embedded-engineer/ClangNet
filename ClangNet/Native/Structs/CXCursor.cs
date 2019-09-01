using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Native Clang Cursor
    /// </summary>
    /// <remarks>
    /// A cursor representing some element in the abstract syntax tree for
    /// a translation unit.
    /// The cursor abstraction unifies the different kinds of entities in a
    /// program--declaration, statements, expressions, references to declarations,
    /// etc.--under a single "cursor" abstraction with a common set of operations.
    /// Common operation for a cursor include: getting the physical location in
    /// a source file where the cursor points, getting the name associated with a
    /// cursor, and retrieving cursors for any child nodes of a particular cursor.
    ///
    /// Cursors can be produced in two specific ways.
    /// <c>clang_getTranslationUnitCursor()</c> produces a cursor for a translation unit,
    /// from which one can use <c>clang_visitChildren()</c> to explore the rest of the
    /// translation unit. <c>clang_getCursor()</c> maps from a physical source location
    /// to the entity that resides at that location, allowing one to map from the
    /// source code into the AST.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXCursor
    {
        /// <summary>
        /// Cursor Kind
        /// </summary>
        public readonly CursorKind Kind;

        /// <summary>
        /// X Data
        /// </summary>
        public readonly int XData;

        /// <summary>
        /// 1st Data of void* [3]
        /// </summary>
        public readonly VoidPtr Data1;

        /// <summary>
        /// 1st Data of void* [3]
        /// </summary>
        public readonly VoidPtr Data2;

        /// <summary>
        /// 1st Data of void* [3]
        /// </summary>
        public readonly VoidPtr Data3;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kind">Cursor Kind</param>
        /// <param name="xdata">X Data</param>
        /// <param name="data">Data Array of void* [3]</param>
        public CXCursor(CursorKind kind, int xdata, VoidPtr[] data)
        {
            this.Kind = kind;
            this.XData = xdata;
            this.Data1 = data[0];
            this.Data2 = data[1];
            this.Data3 = data[2];
        }
    }
}

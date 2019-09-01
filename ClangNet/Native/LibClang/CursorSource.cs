#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // A single translation unit, which resides in an index.
    // struct CXTranslationUnitImpl*
    using CXTranslationUnit = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Cursor Source
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Map a source location to the cursor that describes the entity at that
        /// location in the source code.
        ///
        /// <c>clang_getCursor()</c> maps an arbitrary source location within a translation
        /// unit down to the most specific cursor that describes the entity at that
        /// location.
        /// For example, given an expression <c>x + y</c>, invoking
        /// <c>clang_getCursor()</c> with a source location pointing to "x" will return the
        /// cursor for "x"; similarly for "y".
        /// If the cursor points anywhere between "x" or "y" (e.g., on the + or the whitespace around it),
        /// <c>clang_getCursor()</c> will return a cursor referring to the "+" expression.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <param name="source_location">Source Location</param>
        /// <returns>Cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXCursor clang_getCursor(CXTranslationUnit tu, CXSourceLocation source_location);

        /// <summary>
        /// Retrieve the physical location of the source constructor referenced
        /// by the given cursor.
        ///
        /// The location of a declaration is typically the location of the name of that
        /// declaration, where the name of that declaration would occur if it is
        /// unnamed, or some keyword that introduces that particular declaration.
        /// The location of a reference is where that reference occurs within the
        /// source code.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Physical Source Location</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceLocation clang_getCursorLocation(CXCursor cursor);

        /// <summary>
        /// Retrieve the physical extent of the source construct referenced by
        /// the given cursor.
        ///
        /// The extent of a cursor starts with the file/line/column pointing at the
        /// first character within the source construct that the cursor refers to and
        /// ends with the last character within that source construct.For a
        /// declaration, the extent covers the declaration itself.For a reference,
        /// the extent covers the location of the reference (e.g., where the referenced
        /// entity was actually used).
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Physical Source Extent</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRange clang_getCursorExtent(CXCursor cursor);
    }
}

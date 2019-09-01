#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // CXStringSet*
    using CXStringSetPtr = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Name Mangling
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Retrieve the CXString representing the mangled name of the cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>the CXString representing the mangled name of the cursor</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_Cursor_getMangling(CXCursor cursor);

        /// <summary>
        /// Retrieve the CXStrings representing the mangled symbols of the C++
        /// constructor or destructor at the cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// CXStrings representing the mangled symbols of the C++
        /// constructor or destructor at the cursor
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXStringSetPtr clang_Cursor_getCxxManglings(CXCursor cursor);

        /// <summary>
        /// Retrieve the CXStrings representing the mangled symbols of the ObjC
        /// class interface or implementation at the cursor.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>
        /// the CXStrings representing the mangled symbols of the ObjC
        /// class interface or implementation at the cursor
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXStringSetPtr clang_Cursor_getObjCManglings(CXCursor cursor);
    }
}

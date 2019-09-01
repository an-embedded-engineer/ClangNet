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

    // CXStringSet*
    using CXStringSetPtr = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : String
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Retrieve the character data associated with the given string
        /// </summary>
        /// <param name="string">CXString Data</param>
        /// <returns>Character Data</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ConstCharPtr clang_getCString(CXString @string);

        /// <summary>
        /// Free the given string
        /// </summary>
        /// <param name="string">CXString Data</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeString(CXString @string);

        /// <summary>
        /// Free the given string set
        /// </summary>
        /// <param name="set">CXStringSet Reference Data</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeStringSet(CXStringSetPtr set);
    }
}

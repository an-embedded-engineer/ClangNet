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

    // A single translation unit, which resides in an index.
    // struct CXTranslationUnitImpl*
    using CXTranslationUnit = IntPtr;

    // A particular source file that is part of a translation unit.
    // void*
    using CXFile = IntPtr;

    // time_t
    using TimeT = Int64;

    /// <summary>
    /// Libclang P/Invoke : File
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Retrieve the complete file and path name of the given file.
        /// </summary>
        /// <param name="sFile">CXFile Object</param>
        /// <returns>CXString Object</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getFileName(CXFile sFile);

        /// <summary>
        /// Retrieve the last modification time of the given file.
        /// </summary>
        /// <param name="sFile">CXFile Object</param>
        /// <returns>The Last Modification Time</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern TimeT clang_getFileTime(CXFile sFile);

        /// <summary>
        /// Retrieve the unique ID for the given file.
        /// </summary>
        /// <param name="file">the file to get the ID for.</param>
        /// <param name="out_id">stores the returned CXFileUniqueID.</param>
        /// <returns>If there was a failure getting the unique ID, returns non-zero, otherwise returns 0.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_getFileUniqueID(CXFile file, out CXFileUniqueID out_id);

        /// <summary>
        /// Determine whether the given header is guarded against
        /// multiple inclusions, either with the conventional
        /// #ifndef/#define/#endif macro guards or with #pragma once.
        /// </summary>
        /// <param name="tu">the translation unit</param>
        /// <param name="file">the file</param>
        /// <returns>File Multiple Include Guarded Flag</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_isFileMultipleIncludeGuarded(CXTranslationUnit tu, CXFile file);

        /// <summary>
        /// Retrieve a file handle within the given translation unit.
        /// </summary>
        /// <param name="tu">the translation unit</param>
        /// <param name="file_name">the name of the file.</param>
        /// <returns>the file handle for the named file in the translation unit tu,
        /// or a NULL file handle if the file was not a part of this translation unit.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXFile clang_getFile(CXTranslationUnit tu, string file_name);

        /// <summary>
        /// Retrieve the buffer associated with the given file.
        /// </summary>
        /// <param name="tu">the translation unit</param>
        /// <param name="file">The file for which to retrieve the buffer.</param>
        /// <param name="size">[out] if non-NULL, will be set to the size of the buffer.</param>
        /// <returns>the string buffer</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ConstCharPtr clang_getFileContents(CXTranslationUnit tu, CXFile file, [MarshalAs(UnmanagedType.SysUInt)] out ulong size);

        /// <summary>
        /// Returns non-zero if the <c>file1</c> and <c>file2</c> point to the same file,
        /// or they are both NULL.
        /// </summary>
        /// <param name="file1">file1</param>
        /// <param name="file2">file2</param>
        /// <returns>
        /// Two file is not same : 0
        /// other : non-zero
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_File_isEqual(CXFile file1, CXFile file2);

        /// <summary>
        /// Returns the real path name of <c>file</c>.
        ///
        /// An empty string may be returned. Use <c>clang_getFileName()</c> in that case.
        /// </summary>
        /// <param name="file">file</param>
        /// <returns>the real path</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_File_tryGetRealPathName(CXFile file);
    }
}

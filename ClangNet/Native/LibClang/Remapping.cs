#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // A remapping of original source files and their translated files.
    // void*
    using CXRemapping = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Remapping
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Retrieve a remapping.
        /// </summary>
        /// <param name="path">the path that contains metadata about remappings.</param>
        /// <returns>
        /// the requested remapping. This remapping must be freed
        /// via a call to <c>clang_remap_dispose()</c>.
        /// Can return NULL if an error occurred.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXRemapping clang_getRemappings(string path);

        /// <summary>
        /// Retrieve a remapping.
        /// </summary>
        /// <param name="file_paths">pointer to an array of file paths containing remapping info.</param>
        /// <param name="num_files">number of file paths.</param>
        /// <returns>
        /// the requested remapping. This remapping must be freed
        /// via a call to <c>clang_remap_dispose()</c>.
        /// Can return NULL if an error occurred.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXRemapping clang_getRemappingsFromFileList([MarshalAs(UnmanagedType.LPArray)] string[] file_paths, uint num_files);

        /// <summary>
        /// Determine the number of remappings.
        /// </summary>
        /// <param name="remapping">remapping</param>
        /// <returns>the number of remappings</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_remap_getNumFiles(CXRemapping remapping);

        /// <summary>
        /// Get the original and the associated filename from the remapping.
        /// </summary>
        /// <param name="remapping">remapping</param>
        /// <param name="index">index</param>
        /// <param name="original">If non-NULL, will be set to the original filename.</param>
        /// <param name="transformed">the associated filename</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_remap_getFilenames(CXRemapping remapping, uint index, out CXString original, out CXString transformed);

        /// <summary>
        /// Dispose the remapping.
        /// </summary>
        /// <param name="remapping">remapping</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_remap_dispose(CXRemapping remapping);
    }
}

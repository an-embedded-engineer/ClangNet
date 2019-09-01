using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Clang Unsaved File Extensions
    /// </summary>
    public static class ClangUnsavedFileEx
    {
        /// <summary>
        /// Convert to Native Clang Unsaved File
        /// </summary>
        /// <param name="file">Managed Clang Unsaved File</param>
        /// <returns>Native Clang Unsaved File</returns>
        internal static CXUnsavedFile ToNative(this ClangUnsavedFile file)
        {
            return new CXUnsavedFile(file.FileName, file.Contents);
        }

        /// <summary>
        /// Convert to Native Clang Unsaved File Array
        /// </summary>
        /// <param name="files">Managed Clang Unsaved File List</param>
        /// <returns>Native Clang Unsaved File Array</returns>
        internal static CXUnsavedFile[] ToNativeArray(this IEnumerable<ClangUnsavedFile> files)
        {
            return files.Select(f => f.ToNative()).ToArray();
        }
    }
}

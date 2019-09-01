using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // A particular source file that is part of a translation unit.
    // void*
    using CXFile = IntPtr;

    /// <summary>
    /// Native Clang Index Included File Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxIncludedFileInfo
    {
        /// <summary>
        /// Hash Clang Index Location
        /// </summary>
        public readonly CXIdxLoc HashLoc;

        /// <summary>
        /// Filename
        /// </summary>
        public readonly string Filename;

        /// <summary>
        /// Clang File
        /// </summary>
        public readonly CXFile File;

        /// <summary>
        /// Import Flag
        /// </summary>
        public readonly int IsImport;

        /// <summary>
        /// Angled Flag
        /// </summary>
        public readonly int IsAngled;

        /// <summary>
        /// Module Import Flag
        /// </summary>
        public readonly int IsModuleImport;
    }
}

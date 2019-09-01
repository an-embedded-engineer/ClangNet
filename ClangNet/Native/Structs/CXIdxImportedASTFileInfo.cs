using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // A particular source file that is part of a translation unit.
    // void*
    using CXFile = IntPtr;

    // void*
    using CXModule = IntPtr;

    // The client's data object that is associated with a CXFile.
    // void*
    using CXIdxClientFile = IntPtr;

    /// <summary>
    /// Native Clang Index Imported AST File Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxImportedASTFileInfo
    {
        /// <summary>
        /// Clang File
        /// </summary>
        public readonly CXFile File;

        /// <summary>
        /// Clang Module
        /// </summary>
        public readonly CXModule Module;

        /// <summary>
        /// Clang Index Location
        /// </summary>
        public readonly CXIdxLoc Loc;

        /// <summary>
        /// Implicit Flag
        /// </summary>
        public readonly int IsImplicit;
    }
}

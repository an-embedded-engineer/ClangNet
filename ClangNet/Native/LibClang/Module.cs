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

    // A particular source file that is part of a translation unit.
    // void*
    using CXFile = IntPtr;

    // void*
    using CXModule = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Module Introspection
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Given a CXCursor_ModuleImportDecl cursor, return the associated module.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Module</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXModule clang_Cursor_getModule(CXCursor cursor);

        /// <summary>
        /// Given a CXFile header file, return the module that contains it, if one exists.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <param name="file">File</param>
        /// <returns>Module</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXModule clang_Cursor_getModuleForFile(CXTranslationUnit tu, CXFile file);

        /// <summary>
        /// Get AST File from Module
        /// </summary>
        /// <param name="module">a module object.</param>
        /// <returns>the module file where the provided module object came from.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXFile clang_Module_getASTFile(CXModule module);

        /// <summary>
        /// Get Parent Module
        /// </summary>
        /// <param name="module">a module object.</param>
        /// <returns>
        /// the parent of a sub-module or NULL if the given module is top-level,
        /// e.g. for 'std.vector' it will return the 'std' module.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXModule clang_Module_getParent(CXModule module);

        /// <summary>
        /// Get Module Name
        /// </summary>
        /// <param name="module">a module object.</param>
        /// <returns>
        /// the name of the module, e.g. for the 'std.vector'
        /// sub-module it will return "vector".
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_Module_getName(CXModule module);

        /// <summary>
        /// Get Module Full Name
        /// </summary>
        /// <param name="module">a module object.</param>
        /// <returns>the full name of the module, e.g. "std.vector".</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_Module_getFullName(CXModule module);

        /// <summary>
        /// Check Module is System Module
        /// </summary>
        /// <param name="module">a module object.</param>
        /// <returns>non-zero if the module is a system one.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_Module_isSystem(CXModule module);

        /// <summary>
        /// Get Number of Top Level Headers
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <param name="module">a module object.</param>
        /// <returns>the number of top level headers associated with this module.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Module_getNumTopLevelHeaders(CXTranslationUnit tu, CXModule module);

        /// <summary>
        /// Get Top Level Header
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <param name="module">a module object.</param>
        /// <param name="index">top level header index (zero-based).</param>
        /// <returns>the specified top level header associated with the module.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXFile clang_Module_getTopLevelHeader(CXTranslationUnit tu, CXModule module, uint index);
    }
}

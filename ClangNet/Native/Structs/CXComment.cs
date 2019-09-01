using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // A single translation unit, which resides in an index.
    // struct CXTranslationUnitImpl*
    using CXTranslationUnit = IntPtr;

    // void*
    using VoidPtr = IntPtr;

    /// <summary>
    /// Native Clang Comment
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXComment
    {
        /// <summary>
        /// AST Node Pointer
        /// </summary>
        public readonly VoidPtr ASTNode;

        /// <summary>
        /// Clang Translation Unit
        /// </summary>
        public readonly CXTranslationUnit TranslationUnit;
    }
}

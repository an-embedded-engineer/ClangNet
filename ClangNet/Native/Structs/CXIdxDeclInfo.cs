using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxAttrInfo*
    using ConstCXIdxAttrInfoPtr = IntPtr;

    // const CXIdxEntityInfo*
    using ConstCXIdxEntityInfoPtr = IntPtr;

    // const CXIdxContainerInfo*
    using ConstCXIdxContainerInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Declaration Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxDeclInfo
    {
        /// <summary>
        /// Clang Index Entity Info Pointer
        /// </summary>
        public readonly ConstCXIdxEntityInfoPtr EntityInfo;

        /// <summary>
        /// Clang Cursor
        /// </summary>
        public readonly CXCursor Cursor;

        /// <summary>
        /// Clang Index Location
        /// </summary>
        public readonly CXIdxLoc Loc;

        /// <summary>
        /// Semantic Clang Index Container Info Pointer
        /// </summary>
        public readonly ConstCXIdxContainerInfoPtr SemanticContainer;

        /// <summary>
        /// Lexical Clang Index Container Info Pointer
        /// </summary>
        public readonly ConstCXIdxContainerInfoPtr LexicalContainer;

        /// <summary>
        /// Redeclaration Flag
        /// </summary>
        public readonly int IsRedeclaration;

        /// <summary>
        /// Definition Flag
        /// </summary>
        public readonly int IsDefinition;

        /// <summary>
        /// Container Flag
        /// </summary>
        public readonly int IsContainer;

        /// <summary>
        /// Declaration As Clang Index Container Info Pointer
        /// </summary>
        public readonly ConstCXIdxContainerInfoPtr DeclAsContainer;

        /// <summary>
        /// Implicit Flag
        /// </summary>
        public readonly int IsImplicit;

        /// <summary>
        /// Clang Index Attribute Info Array Pointer
        /// </summary>
        public readonly ConstCXIdxAttrInfoPtr Attributes;

        /// <summary>
        /// Number of Attribute Info Array
        /// </summary>
        public readonly uint NumAttributes;

        /// <summary>
        /// Index Declaration Info Flags
        /// </summary>
        public readonly IndexDeclInfoFlags Flags;
    }
}

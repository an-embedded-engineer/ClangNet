using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxAttrInfo*
    using ConstCXIdxAttrInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Entity Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxEntityInfo
    {
        /// <summary>
        /// Index Entity Kind
        /// </summary>
        public readonly IndexEntityKind Kind;

        /// <summary>
        /// Index Entity C++ Template Kind
        /// </summary>
        public readonly IndexEntityCxxTemplateKind CxxTemplateKind;

        /// <summary>
        /// Index Entity Language
        /// </summary>
        public readonly IndexEntityLanguage Lang;

        /// <summary>
        /// Entity Name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Entity USR
        /// </summary>
        public readonly string USR;

        /// <summary>
        /// Clang Cursor
        /// </summary>
        public readonly CXCursor Cursor;

        /// <summary>
        /// Clang Index Attribute Info Array Pointer
        /// </summary>
        public readonly ConstCXIdxAttrInfoPtr Attributes;

        /// <summary>
        /// Number of Attribute Info Array
        /// </summary>
        public readonly uint NumAttributes;
    }
}

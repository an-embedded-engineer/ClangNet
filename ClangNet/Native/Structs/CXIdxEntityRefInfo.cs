using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxEntityInfo*
    using ConstCXIdxEntityInfoPtr = IntPtr;

    // const CXIdxContainerInf*
    using ConstCXIdxContainerInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Entity Reference Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxEntityRefInfo
    {
        /// <summary>
        /// Index Entity Reference Kind
        /// </summary>
        public readonly IndexEntityRefKind Kind;

        /// <summary>
        /// Clang Cursor
        /// </summary>
        public readonly CXCursor Cursor;

        /// <summary>
        /// Clang Index Location
        /// </summary>
        public readonly CXIdxLoc Loc;

        /// <summary>
        /// Referenced Clang Index Entity Info Pointer
        /// </summary>
        public readonly ConstCXIdxEntityInfoPtr ReferencedEntity;

        /// <summary>
        /// Parent Clang Index Entity Info Pointer
        /// </summary>
        public readonly ConstCXIdxEntityInfoPtr ParentEntity;

        /// <summary>
        /// Clang Index Container Info Pointer
        /// </summary>
        public readonly ConstCXIdxContainerInfoPtr Container;

        /// <summary>
        /// Symbol Role
        /// </summary>
        public readonly SymbolRole Role;
    }
}

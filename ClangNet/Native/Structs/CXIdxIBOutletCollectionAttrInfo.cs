using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxAttrInfo*
    using ConstCXIdxAttrInfoPtr = IntPtr;

    // const CXIdxEntityInfo*
    using ConstCXIdxEntityInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index IBOutlet Collection Attribute Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxIBOutletCollectionAttrInfo
    {
        /// <summary>
        /// Clang Index Attriubute Info Pointer
        /// </summary>
        public readonly ConstCXIdxAttrInfoPtr AttrInfo;

        /// <summary>
        /// Objective-C Clang Index Entity Info Pointer
        /// </summary>
        public readonly ConstCXIdxEntityInfoPtr ObjcClass;

        /// <summary>
        /// Class Clang Cursor
        /// </summary>
        public readonly CXCursor ClassCursor;

        /// <summary>
        /// Class Clang Index Location
        /// </summary>
        public readonly CXIdxLoc ClassLoc;
    }
}

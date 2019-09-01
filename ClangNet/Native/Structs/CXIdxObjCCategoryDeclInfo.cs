using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxObjCContainerDeclInfo*
    using ConstCXIdxObjCContainerDeclInfoPtr = IntPtr;

    // const CXIdxEntityInfo*
    using ConstCXIdxEntityInfoPtr = IntPtr;

    // const CXIdxObjCProtocolRefListInfo*
    using ConstCXIdxObjCProtocolRefListInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Objective-C Category Declaration Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxObjCCategoryDeclInfo
    {
        /// <summary>
        /// Clang Index Objective-C Container Declaration Info Pointer
        /// </summary>
        public readonly ConstCXIdxObjCContainerDeclInfoPtr ContainerInfo;

        /// <summary>
        /// Objective-C Class Clang Index Entity Info Pointer
        /// </summary>
        public readonly ConstCXIdxEntityInfoPtr ObjCClass;

        /// <summary>
        /// Class Clang Cursor
        /// </summary>
        public readonly CXCursor ClassCursor;

        /// <summary>
        /// Class Clang Index Location
        /// </summary>
        public readonly CXIdxLoc ClassLoc;

        /// <summary>
        /// Clang Index Objective-C Protocol Reference List Info Pointer
        /// </summary>
        public readonly ConstCXIdxObjCProtocolRefListInfoPtr Protocols;
    }
}

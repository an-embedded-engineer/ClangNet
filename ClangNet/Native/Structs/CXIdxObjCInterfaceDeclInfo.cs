using System;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    // const CXIdxObjCContainerDeclInfo*
    using ConstCXIdxObjCContainerDeclInfoPtr = IntPtr;

    // const CXIdxBaseClassInfo*
    using ConstCXIdxBaseClassInfoPtr = IntPtr;

    // const CXIdxObjCProtocolRefListInfo*
    using ConstCXIdxObjCProtocolRefListInfoPtr = IntPtr;

    /// <summary>
    /// Native Clang Index Objective-C Interface Declaration Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXIdxObjCInterfaceDeclInfo
    {
        /// <summary>
        /// Clang Index Objective-C Container Declaration Info Pointer
        /// </summary>
        public readonly ConstCXIdxObjCContainerDeclInfoPtr ContainerInfo;

        /// <summary>
        /// Super Clang Index Base Class Info Pointer
        /// </summary>
        public readonly ConstCXIdxBaseClassInfoPtr SuperInfo;

        /// <summary>
        /// Clang Index Objective-C Protocol Reference List Info Pointer
        /// </summary>
        public readonly ConstCXIdxObjCProtocolRefListInfoPtr Protocols;
    }
}

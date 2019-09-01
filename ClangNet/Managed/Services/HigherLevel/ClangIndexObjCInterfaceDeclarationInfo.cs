using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Objective-C Interface Declaration Info
    /// </summary>
    public class ClangIndexObjCInterfaceDeclarationInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Objective-C Interface Declaration Info
        /// </summary>
        internal CXIdxObjCInterfaceDeclInfo Info { get; }

        /// <summary>
        /// Clang Index Objective-C Container Declaration Info
        /// </summary>
        public ClangIndexObjCContainerDeclarationInfo Container
        {
            get { return this.Info.ContainerInfo.ToManaged<ClangIndexObjCContainerDeclarationInfo>(); }
        }

        /// <summary>
        /// Super Class Clang Index Base Class Info
        /// </summary>
        public ClangIndexBaseClassInfo Super
        {
            get { return this.Info.SuperInfo.ToManaged<ClangIndexBaseClassInfo>(); }
        }

        /// <summary>
        /// Clang Index Objective-C Protocol Reference List Info
        /// </summary>
        public ClangIndexObjCProtocolReferenceListInfo ProtocolReferenceList
        {
            get { return this.Info.Protocols.ToManaged<ClangIndexObjCProtocolReferenceListInfo>(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Objective-C Interface Declaration Info Address</param>
        internal ClangIndexObjCInterfaceDeclarationInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxObjCInterfaceDeclInfo>();
        }
    }
}

using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Objective-C Category Declaration Info
    /// </summary>
    public class ClangIndexObjCCategoryDeclarationInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Objective-C Category Declaration Info
        /// </summary>
        internal CXIdxObjCCategoryDeclInfo Info { get; }

        /// <summary>
        /// Clang Index Objective-C Container Declaration Info
        /// </summary>
        public ClangIndexObjCContainerDeclarationInfo Container
        {
            get { return this.Info.ContainerInfo.ToManaged<ClangIndexObjCContainerDeclarationInfo>(); }
        }

        /// <summary>
        /// Objective-C Clang Index Entity Info
        /// </summary>
        public ClangIndexEntityInfo ObjCClass
        {
            get { return this.Info.ObjCClass.ToManaged<ClangIndexEntityInfo>(); }
        }

        /// <summary>
        /// Class Clang Cursor
        /// </summary>
        public ClangCursor ClassCursor
        {
            get { return this.Info.ClassCursor.ToManaged(); }
        }

        /// <summary>
        /// Class Clang Index Location
        /// </summary>
        public ClangIndexLocation ClassLocation
        {
            get { return this.Info.ClassLoc.ToManaged(); }
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
        /// <param name="address">Native Clang Index Objective-C Category Declaration Info Address</param>
        internal ClangIndexObjCCategoryDeclarationInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxObjCCategoryDeclInfo>();
        }
    }
}

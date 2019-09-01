using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Objective-C Container Declaration Info
    /// </summary>
    public class ClangIndexObjCContainerDeclarationInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Objective-C Container Declaration Info
        /// </summary>
        internal CXIdxObjCContainerDeclInfo Info { get; }

        /// <summary>
        /// Clang Index Declaration Info
        /// </summary>
        public ClangIndexDeclarationInfo Declaration
        {
            get { return this.Info.DeclInfo.ToManaged<ClangIndexDeclarationInfo>(); }
        }

        /// <summary>
        /// Index Objective-C Container Kind
        /// </summary>
        public IndexObjCContainerKind Kind
        {
            get { return this.Info.Kind; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Objective-C Container Declaration Info Address</param>
        internal ClangIndexObjCContainerDeclarationInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxObjCContainerDeclInfo>();
        }
    }
}

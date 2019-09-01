using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Objective-C Property Declaration Info
    /// </summary>
    public class ClangIndexObjCPropertyDeclarationInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Objective-C Property Declaration Info
        /// </summary>
        internal CXIdxObjCPropertyDeclInfo Info { get; }

        /// <summary>
        /// Clang Index Declaration Info
        /// </summary>
        public ClangIndexDeclarationInfo Declaration
        {
            get { return this.Info.DeclInfo.ToManaged<ClangIndexDeclarationInfo>(); }
        }

        /// <summary>
        /// Getter Clang Index Entity Info
        /// </summary>
        public ClangIndexEntityInfo Getter
        {
            get { return this.Info.Getter.ToManaged<ClangIndexEntityInfo>(); }
        }

        /// <summary>
        /// Setter Clang Index Entity Info
        /// </summary>
        public ClangIndexEntityInfo Setter
        {
            get { return this.Info.Setter.ToManaged<ClangIndexEntityInfo>(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Objective-C Property Declaration Info Address</param>
        internal ClangIndexObjCPropertyDeclarationInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxObjCPropertyDeclInfo>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index C++ Class Declaration Info
    /// </summary>
    public class ClangIndexCxxClassDeclarationInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index C++ Class Declaration Info
        /// </summary>
        internal CXIdxCXXClassDeclInfo Info { get; }

        /// <summary>
        /// Clang Index Declaration Info
        /// </summary>
        public ClangIndexDeclarationInfo Declaration
        {
            get { return new ClangIndexDeclarationInfo(this.Info.DeclInfo); }
        }

        /// <summary>
        /// Base Class Count
        /// </summary>
        public int BaseCount
        {
            get { return (int)this.Info.NumBases; }
        }

        /// <summary>
        /// Clang Index Base Class Info List
        /// </summary>
        public IEnumerable<ClangIndexBaseClassInfo> Bases
        {
            get { return this.Info.Bases.ToManagedObjects<CXIdxBaseClassInfo, ClangIndexBaseClassInfo>(this.BaseCount); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index C++ Class Declaration Info Address</param>
        internal ClangIndexCxxClassDeclarationInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxCXXClassDeclInfo>();
        }
    }
}

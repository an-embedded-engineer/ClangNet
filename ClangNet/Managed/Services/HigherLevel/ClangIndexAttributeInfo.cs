using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Attribute Info
    /// </summary>
    public class ClangIndexAttributeInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Attribute Info
        /// </summary>
        internal CXIdxAttrInfo Info { get; }

        /// <summary>
        /// Index Attribute Kind
        /// </summary>
        public IndexAttributeKind Kind
        {
            get { return this.Info.Kind; }
        }

        /// <summary>
        /// Clang Cursor
        /// </summary>
        public ClangCursor Cursor
        {
            get { return this.Info.Cursor.ToManaged(); }
        }

        /// <summary>
        /// Clang Index Location
        /// </summary>
        public ClangIndexLocation Location
        {
            get { return this.Info.Loc.ToManaged(); }
        }

        /// <summary>
        /// Clang IBOutlet Collection Attribute Info
        /// </summary>
        public ClangIndexIBOutletCollectionAttributeInfo IBOutletCollectionAttribute
        {
            get { return LibClang.clang_index_getIBOutletCollectionAttrInfo(this.Address).ToManaged<ClangIndexIBOutletCollectionAttributeInfo>(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Attribute Info Address</param>
        internal ClangIndexAttributeInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxAttrInfo>();
        }
    }
}

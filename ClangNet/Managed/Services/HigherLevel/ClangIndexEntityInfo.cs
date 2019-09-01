using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Entity Info
    /// </summary>
    public class ClangIndexEntityInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Entity Info
        /// </summary>
        internal CXIdxEntityInfo Info { get; }

        /// <summary>
        /// Index Entity Kind
        /// </summary>
        public IndexEntityKind Kind
        {
            get { return this.Info.Kind; }
        }

        /// <summary>
        /// Index Entity C++ Template Kind
        /// </summary>
        public IndexEntityCxxTemplateKind CxxTemplateKind
        {
            get { return this.Info.CxxTemplateKind; }
        }

        /// <summary>
        /// Index Entity Lanagage
        /// </summary>
        public IndexEntityLanguage Language
        {
            get { return this.Info.Lang; }
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return this.Info.Name; }
        }

        /// <summary>
        /// USR
        /// </summary>
        public string USR
        {
            get { return this.Info.USR; }
        }

        /// <summary>
        /// Clang Cursor
        /// </summary>
        public ClangCursor Cursor
        {
            get { return this.Info.Cursor.ToManaged(); }
        }

        /// <summary>
        /// Attribute Count
        /// </summary>
        public int AttributeCount
        {
            get { return (int)this.Info.NumAttributes; }
        }

        /// <summary>
        /// Clang Index Attribute Info List
        /// </summary>
        public IEnumerable<ClangIndexAttributeInfo> Attributes
        {
            get { return this.Info.Attributes.ToManagedObjects<CXIdxAttrInfo, ClangIndexAttributeInfo>(this.AttributeCount); }
        }

        /// <summary>
        /// Clang Index Client Entity
        /// </summary>
        public ClangIndexClientEntity ClientEntity
        {
            get { return LibClang.clang_index_getClientEntity(this.Address).ToManaged<ClangIndexClientEntity>(); }
            set { LibClang.clang_index_setClientEntity(this.Address, value.Address); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Entity Info Address</param>
        internal ClangIndexEntityInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxEntityInfo>();
        }
    }
}

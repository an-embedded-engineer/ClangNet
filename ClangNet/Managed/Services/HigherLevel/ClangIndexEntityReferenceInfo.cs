using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Entity Reference Info
    /// </summary>
    public class ClangIndexEntityReferenceInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Entity Reference Info
        /// </summary>
        internal CXIdxEntityRefInfo Info { get; }

        /// <summary>
        /// Index Entity Reference Kind
        /// </summary>
        public IndexEntityRefKind Kind
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
        /// Referenced Clang Index Entity Info
        /// </summary>
        public ClangIndexEntityInfo ReferencedEntity
        {
            get { return new ClangIndexEntityInfo(this.Info.ReferencedEntity); }
        }

        /// <summary>
        /// Parent Clang Index Entity Info
        /// </summary>
        public ClangIndexEntityInfo ParentEntity
        {
            get { return new ClangIndexEntityInfo(this.Info.ParentEntity); }
        }

        /// <summary>
        /// Clang Index Container Info
        /// </summary>
        public ClangIndexContainerInfo Container
        {
            get { return new ClangIndexContainerInfo(this.Info.Container); }
        }

        /// <summary>
        /// Symbol Role
        /// </summary>
        public SymbolRole Role
        {
            get { return this.Info.Role; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Entity Reference Info Address</param>
        internal ClangIndexEntityReferenceInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxEntityRefInfo>();
        }
    }
}

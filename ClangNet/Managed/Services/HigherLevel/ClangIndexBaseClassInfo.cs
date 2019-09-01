using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Base Class Info
    /// </summary>
    public class ClangIndexBaseClassInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Base Class Info
        /// </summary>
        internal CXIdxBaseClassInfo Info { get; }

        /// <summary>
        /// Base Clang Index Entity Info
        /// </summary>
        public ClangIndexEntityInfo Base
        {
            get { return this.Info.Base.ToManaged<ClangIndexEntityInfo>(); }
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
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Base Class Info Address</param>
        internal ClangIndexBaseClassInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxBaseClassInfo>();
        }
    }
}

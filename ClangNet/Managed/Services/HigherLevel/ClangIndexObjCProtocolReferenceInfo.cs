using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Objective-C Protocol Reference Info
    /// </summary>
    public class ClangIndexObjCProtocolReferenceInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Objective-C Protocol Reference Info
        /// </summary>
        internal CXIdxObjCProtocolRefInfo Info { get; }

        /// <summary>
        /// Base Clang Index Entity Info
        /// </summary>
        public ClangIndexEntityInfo Base
        {
            get { return this.Info.Protocol.ToManaged<ClangIndexEntityInfo>(); }
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
        /// <param name="address">Native Clang Index Objective-C Protocol Reference Info Address</param>
        internal ClangIndexObjCProtocolReferenceInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxObjCProtocolRefInfo>();
        }
    }
}

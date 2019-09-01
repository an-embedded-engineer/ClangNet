using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Objective-C Protocol Reference List Info
    /// </summary>
    public class ClangIndexObjCProtocolReferenceListInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Objective-C Protocol Reference List Info
        /// </summary>
        internal CXIdxObjCProtocolRefListInfo Info { get; }

        /// <summary>
        /// Protocol Count
        /// </summary>
        public int ProtocolCount
        {
            get { return (int)this.Info.NumProtocols; }
        }

        /// <summary>
        /// Protocol Clang Index Attribute Info List
        /// </summary>
        public IEnumerable<ClangIndexAttributeInfo> Protocols
        {
            get { return this.Info.Protocols.ToManagedObjects<CXIdxObjCProtocolRefInfo, ClangIndexAttributeInfo>(this.ProtocolCount); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Objective-C Protocol Reference List Info Address</param>
        internal ClangIndexObjCProtocolReferenceListInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxObjCProtocolRefListInfo>();
        }
    }
}

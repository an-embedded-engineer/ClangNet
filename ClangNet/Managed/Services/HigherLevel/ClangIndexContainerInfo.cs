using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Container Info
    /// </summary>
    public class ClangIndexContainerInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Container Info
        /// </summary>
        internal CXIdxContainerInfo Info { get; }

        /// <summary>
        /// Clang Cursor
        /// </summary>
        public ClangCursor Cursor
        {
            get { return this.Info.Cursor.ToManaged(); }
        }

        /// <summary>
        /// Clang Index Client Container
        /// </summary>
        public ClangIndexClientContainer ClientContainer
        {
            get { return new ClangIndexClientContainer(LibClang.clang_index_getClientContainer(this.Address)); }
            set { LibClang.clang_index_setClientContainer(this.Address, value.Address); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Container Info Address</param>
        internal ClangIndexContainerInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxContainerInfo>();
        }
    }
}

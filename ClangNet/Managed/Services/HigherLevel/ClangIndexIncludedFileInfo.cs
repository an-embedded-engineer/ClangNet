using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Included File Info
    /// </summary>
    public class ClangIndexIncludedFileInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Included File Info
        /// </summary>
        internal CXIdxIncludedFileInfo Info { get; }

        /// <summary>
        /// Hash Clang Index Location
        /// </summary>
        public ClangIndexLocation HashLocation
        {
            get { return this.Info.HashLoc.ToManaged(); }
        }

        /// <summary>
        /// File Name
        /// </summary>
        public string Filename
        {
            get { return this.Info.Filename; }
        }

        /// <summary>
        /// Clang File
        /// </summary>
        public ClangFile File
        {
            get { return this.Info.File.ToManaged<ClangFile>(); }
        }

        /// <summary>
        /// Import Flag
        /// </summary>
        public bool IsImport
        {
            get { return this.Info.IsImport.ToBool(); }
        }

        /// <summary>
        /// Angled Flag
        /// </summary>
        public bool IsAngled
        {
            get { return this.Info.IsAngled.ToBool(); }
        }

        /// <summary>
        /// Module Import Flag
        /// </summary>
        public bool IsModuleImport
        {
            get { return this.Info.IsModuleImport.ToBool(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Included File Info Address</param>
        internal ClangIndexIncludedFileInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxIncludedFileInfo>();
        }
    }
}

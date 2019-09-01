using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Imporeted AST File Info
    /// </summary>
    public class ClangIndexImportedASTFileInfo : ClangIndexInfo
    {
        /// <summary>
        /// Native Clang Index Imporeted AST File Info
        /// </summary>
        internal CXIdxImportedASTFileInfo Info { get; }

        /// <summary>
        /// Clang File
        /// </summary>
        public ClangFile File
        {
            get { return this.Info.File.ToManaged<ClangFile>(); }
        }

        /// <summary>
        /// Clang Module
        /// </summary>
        public ClangModule Module
        {
            get { return this.Info.Module.ToManaged<ClangModule>(); }
        }

        /// <summary>
        /// Clang Index Location
        /// </summary>
        public ClangIndexLocation Location
        {
            get { return this.Info.Loc.ToManaged(); }
        }

        /// <summary>
        /// Implicit Flag
        /// </summary>
        public bool IsImplicit
        {
            get { return this.Info.IsImplicit.ToBool(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Imporeted AST File Info Address</param>
        internal ClangIndexImportedASTFileInfo(IntPtr address) : base(address)
        {
            this.Info = this.Address.ToNativeStuct<CXIdxImportedASTFileInfo>();
        }
    }
}

using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Target Info
    /// </summary>
    public class ClangTargetInfo : ClangObject, IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Target Info Pointer</param>
        internal ClangTargetInfo(IntPtr handle) : base(handle)
        {

        }

        /// <summary>
        /// Normalized Target Triple
        /// </summary>
        public string Triple
        {
            get { return LibClang.clang_TargetInfo_getTriple(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Pointer Width
        /// </summary>
        public int PointerWidth
        {
            get { return LibClang.clang_TargetInfo_getPointerWidth(this.Handle); }
        }

        /// <summary>
        /// Dispose Clang Target Info
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_TargetInfo_dispose(this.Handle);
        }
    }
}

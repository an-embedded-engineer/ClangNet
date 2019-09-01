using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Remapping
    /// </summary>
    public class ClangRemapping : ClangObject, IDisposable
    {
        /// <summary>
        /// File Count
        /// </summary>
        public int FileCount
        {
            get { return (int)LibClang.clang_remap_getNumFiles(this.Handle); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Remapping Pointer</param>
        internal ClangRemapping(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get File Name Map
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Clang File Name Map</returns>
        public ClangFileNameMap GetFileNames(int index)
        {
            LibClang.clang_remap_getFilenames(this.Handle, (uint)index, out var native_original, out var native_transformed);

            var original = native_original.ToManaged();

            var transformed = native_transformed.ToManaged();

            return new ClangFileNameMap(original, transformed);
        }

        /// <summary>
        /// Dispose Clang Remapping
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_remap_dispose(this.Handle);
        }
    }
}

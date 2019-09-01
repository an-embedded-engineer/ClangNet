using System;
using System.Collections.Generic;
using System.Text;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Virtual File Overlay
    /// </summary>
    public class ClangVirtualFileOverlay : ClangObject, IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Virtual File Overlay Pointer</param>
        internal ClangVirtualFileOverlay(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Add File Mapping
        /// </summary>
        /// <param name="virtual_path">Virtual File Path</param>
        /// <param name="real_path">Real File Path</param>
        /// <returns>Erro rCode</returns>
        public ErrorCode AddFileMapping(string virtual_path, string real_path)
        {
            return LibClang.clang_VirtualFileOverlay_addFileMapping(this.Handle, virtual_path, real_path);
        }

        /// <summary>
        /// Set Case Sensitivity
        /// </summary>
        /// <param name="case_sensitive">Case Sensitivity</param>
        /// <returns>Error Code</returns>
        public ErrorCode SetCaseSensitivity(int case_sensitive)
        {
            return LibClang.clang_VirtualFileOverlay_setCaseSensitivity(this.Handle, case_sensitive);
        }

        /// <summary>
        /// Write Out Virtual File Overlay To String
        /// </summary>
        /// <param name="out_str">Virtual File Overlay String</param>
        /// <returns>Error Code</returns>
        public ErrorCode WriteToBuffer(out string out_str)
        {
            var ret = LibClang.clang_VirtualFileOverlay_writeToBuffer(this.Handle, 0u, out var char_ptr, out var size);

            out_str = char_ptr.ToManagedString((int)size);

            LibClang.clang_free(char_ptr);

            return ret;
        }

        /// <summary>
        /// Dispose Clang Virtual File Overlay
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_VirtualFileOverlay_dispose(this.Handle);
        }
    }
}

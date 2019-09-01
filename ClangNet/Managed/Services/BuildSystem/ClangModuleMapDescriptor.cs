using System;
using System.Collections.Generic;
using System.Text;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Module Map Descriptor
    /// </summary>
    public class ClangModuleMapDescriptor : ClangObject, IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Module Map Descriptor Pointer</param>
        internal ClangModuleMapDescriptor(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Set Framework Module Name
        /// </summary>
        /// <param name="name">Framework Module Name</param>
        /// <returns>Error Code</returns>
        public ErrorCode SetFrameworkModuleName(string name)
        {
            return LibClang.clang_ModuleMapDescriptor_setFrameworkModuleName(this.Handle, name);
        }

        /// <summary>
        /// Set Umbrella Header
        /// </summary>
        /// <param name="name">Umbrella Header Name</param>
        /// <returns>Error Code</returns>
        public ErrorCode SetUmbrellaHeader(string name)
        {
            return LibClang.clang_ModuleMapDescriptor_setUmbrellaHeader(this.Handle, name);
        }

        /// <summary>
        /// Write Out Module Map Descriptor To String
        /// </summary>
        /// <param name="out_str">Module Map Descriptor String</param>
        /// <returns>Error Code</returns>
        public ErrorCode WriteToBuffer(out string out_str)
        {
            var ret = LibClang.clang_ModuleMapDescriptor_writeToBuffer(this.Handle, 0u, out var char_ptr, out var size);

            out_str = char_ptr.ToManagedString((int)size);

            LibClang.clang_free(char_ptr);

            return ret;
        }

        /// <summary>
        /// Dispose Module Map Descriptor
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_ModuleMapDescriptor_dispose(this.Handle);
        }
    }
}

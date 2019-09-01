using ClangNet.Native;
using System;
using System.Runtime.InteropServices;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Platform Availability
    /// </summary>
    public class ClangPlatformAvailability : ClangObject, IDisposable
    {
        /// <summary>
        /// Native Clang Platform Availability
        /// </summary>
        internal CXPlatformAvailability Source { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Platform Availability Pointer</param>
        internal ClangPlatformAvailability(IntPtr handle) : base(handle)
        {
            this.Source = this.Handle.ToNativeStuct<CXPlatformAvailability>();
        }

        /// <summary>
        /// Dispose Clang Platform Availability
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_disposeCXPlatformAvailability(this.Handle);
        }
    }
}

using ClangNet.Native;
using System;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Printing Policy
    /// </summary>
    public class ClangPrintingPolicy : ClangObject, IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Printing Policy Pointer</param>
        internal ClangPrintingPolicy(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get Property
        /// </summary>
        /// <param name="property">Printing Policy Property</param>
        /// <returns>Property Value</returns>
        public uint GetProperty(PrintingPolicyProperty property)
        {
            return LibClang.clang_PrintingPolicy_getProperty(this.Handle, property);
        }

        /// <summary>
        /// Set Property
        /// </summary>
        /// <param name="property">Printing Policy Property</param>
        /// <param name="value">Property Value</param>
        public void SetProperty(PrintingPolicyProperty property, uint value)
        {
            LibClang.clang_PrintingPolicy_setProperty(this.Handle, property, value);
        }

        /// <summary>
        /// Dispose Clang Printing Policy
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_PrintingPolicy_dispose(this.Handle);
        }
    }
}

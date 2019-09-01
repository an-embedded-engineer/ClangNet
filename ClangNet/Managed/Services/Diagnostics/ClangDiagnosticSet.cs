using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Diagnostic Set
    /// </summary>
    public class ClangDiagnosticSet : ClangObject, IDisposable
    {
        /// <summary>
        /// Diagnostic Count
        /// </summary>
        public int Count
        {
            get { return (int)LibClang.clang_getNumDiagnosticsInSet(this.Handle); }
        }

        /// <summary>
        /// Clang Diagnostics
        /// </summary>
        public IEnumerable<ClangDiagnostic> Items
        {
            get { return Enumerable.Range(0, this.Count).Select(i => this.Get(i)); }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Clang Diagnostic</returns>
        public ClangDiagnostic this[int i]
        {
            get { return this.Items.ElementAt(i); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Diagnostic Set Pointer</param>
        internal ClangDiagnosticSet(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get Clang Diagnostic
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Clang Diagnostic</returns>
        public ClangDiagnostic Get(int index)
        {
            var diag = LibClang.clang_getDiagnosticInSet(this.Handle, (uint)index);
            return new ClangDiagnostic(diag);
        }

        /// <summary>
        /// Dispose Clang Diagnostic Set
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_disposeDiagnosticSet(this.Handle);
        }
    }
}

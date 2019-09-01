using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Translation Unit Resource Usage
    /// </summary>
    public class ClangTranslationUnitResourceUsage : IDisposable
    {
        /// <summary>
        /// Native Clang Translation Unit Resource Usage
        /// </summary>
        private CXTUResourceUsage Source { get; }

        /// <summary>
        /// Entry Count
        /// </summary>
        public int EntryCount
        {
            get { return (int)this.Source.NumEntries; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Native Clang Translation Unit Resource Usage</param>
        internal ClangTranslationUnitResourceUsage(CXTUResourceUsage source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Get Clang Translation Unit Resource Usage Entry
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Clang Translation Unit Resource Usage Entry</returns>
        public ClangTranslationUnitResourceUsageEntry GetEntry(int i)
        {
            return this.Source.Entries.ToNativeStuct<CXTUResourceUsageEntry>(i).ToManaged();
        }

        /// <summary>
        /// Dispose Clang Translation Unit Resource Usage
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_disposeCXTUResourceUsage(this.Source);
        }
    }
}

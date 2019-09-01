using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Translation Unit Resource Usaage Entry
    /// </summary>
    public class ClangTranslationUnitResourceUsageEntry
    {
        /// <summary>
        /// Native Clang Translation Unit Resource Usage Entry
        /// </summary>
        internal CXTUResourceUsageEntry Source { get; }

        /// <summary>
        /// Resource Usage Kind
        /// </summary>
        public ResourceUsageKind Kind
        {
            get { return this.Source.Kind; }
        }

        /// <summary>
        /// Amount
        /// </summary>
        public ulong Amount
        {
            get { return this.Source.Amount; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entry">Native Clang Translation Unit Resource Usage Entry</param>
        internal ClangTranslationUnitResourceUsageEntry(CXTUResourceUsageEntry entry)
        {
            this.Source = entry;
        }
    }

}

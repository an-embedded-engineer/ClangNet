using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXTUResourceUsageEntry Extensions
    /// </summary>
    public static class CXTUResourceUsageEntryEx
    {
        /// <summary>
        /// Convert to Managed Clang Translation Unit Resource Usage Entry
        /// </summary>
        /// <param name="entry">Native Clang Translation Unit Resource Usage Entry</param>
        /// <returns>Managed Clang Translation Unit Resource Usage Entry</returns>
        internal static ClangTranslationUnitResourceUsageEntry ToManaged(this CXTUResourceUsageEntry entry)
        {
            return new ClangTranslationUnitResourceUsageEntry(entry);
        }
    }
}

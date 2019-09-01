using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXTUResourceUsage Extensions
    /// </summary>
    public static class CXTUResourceUsageEx
    {
        /// <summary>
        /// Convert to Managed Clang Translation Unit Resource Usage
        /// </summary>
        /// <param name="usage">Native Clang Translation Unit Resource Usage</param>
        /// <returns>Managed Clang Translation Unit Resource Usage</returns>
        internal static ClangTranslationUnitResourceUsage ToManaged(this CXTUResourceUsage usage)
        {
            return new ClangTranslationUnitResourceUsage(usage);
        }
    }
}

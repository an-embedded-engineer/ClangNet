using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXIdxLoc Extensions
    /// </summary>
    public static class CXIdxLocEx
    {
        /// <summary>
        /// Convert to Managed Clang Index Location
        /// </summary>
        /// <param name="loc">Native Clang Index Location</param>
        /// <returns>Managed Clang Index Location</returns>
        internal static ClangIndexLocation ToManaged(this CXIdxLoc loc)
        {
            return new ClangIndexLocation(loc);
        }
    }
}

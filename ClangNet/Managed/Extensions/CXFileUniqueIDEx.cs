using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXFileUniqueID Extensions
    /// </summary>
    public static class CXFileUniqueIDEx
    {
        /// <summary>
        /// Convert to Managed Clang Cursor
        /// </summary>
        /// <param name="file_unique_id">Native Clang File Unique ID</param>
        /// <returns>Managed Clang File Unique ID</returns>
        internal static ClangFileUniqueId ToManaged(this CXFileUniqueID file_unique_id)
        {
            return new ClangFileUniqueId(file_unique_id);
        }
    }
}

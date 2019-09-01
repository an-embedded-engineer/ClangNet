using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXComment Extensions
    /// </summary>
    public static class CXCommentEx
    {
        /// <summary>
        /// Convert to Managed Clang Comment
        /// </summary>
        /// <param name="comment">Native Clang Comment</param>
        /// <returns>Managed Clang Comment</returns>
        internal static ClangComment ToManaged(this CXComment comment)
        {
            return new ClangComment(comment);
        }
    }
}

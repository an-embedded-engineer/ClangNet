using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXToken Extensions
    /// </summary>
    public static class CXTokenEx
    {
        /// <summary>
        /// Convert to Managed Clang Token
        /// </summary>
        /// <param name="token">Native Clang Token</param>
        /// <param name="tu">Native Clang Translation Unit Pointer</param>
        /// <returns>Managed Clang Token</returns>
        internal static ClangToken ToManaged(this CXToken token, IntPtr tu)
        {
            return new ClangToken(tu, token);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXSourceRange Extensions
    /// </summary>
    public static class CXSourceRangeEx
    {
        /// <summary>
        /// Convert to Managed Clang Source Range
        /// </summary>
        /// <param name="range">Native Clang Source Range</param>
        /// <returns>Managed Clang Source Range</returns>
        internal static ClangSourceRange ToManaged(this CXSourceRange range)
        {
            return new ClangSourceRange(range);
        }
    }
}

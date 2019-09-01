using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXSourceLocation Extensions
    /// </summary>
    public static class CXSourceLocationEx
    {
        /// <summary>
        /// Convert to Managed Clang Source Location
        /// </summary>
        /// <param name="loc">Native Clang Source Location</param>
        /// <returns>Managed Clang Source Location</returns>
        internal static ClangSourceLocation ToManaged(this CXSourceLocation loc)
        {
            return new ClangSourceLocation(loc);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXType Extensions
    /// </summary>
    public static class CXTypeEx
    {
        /// <summary>
        /// Convert to Managed Clang Type
        /// </summary>
        /// <param name="type">Native Clang Type</param>
        /// <returns>Managed Clang Type</returns>
        internal static ClangType ToManaged(this CXType type)
        {
            return new ClangType(type);
        }
    }
}

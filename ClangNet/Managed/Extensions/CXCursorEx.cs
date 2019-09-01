using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXCursor Extensions
    /// </summary>
    public static class CXCursorEx
    {
        /// <summary>
        /// Convert to Managed Clang Cursor
        /// </summary>
        /// <param name="cursor">Native Clang Cursor</param>
        /// <returns>Managed Clang Cursor</returns>
        internal static ClangCursor ToManaged(this CXCursor cursor)
        {
            return new ClangCursor(cursor);
        }
    }
}

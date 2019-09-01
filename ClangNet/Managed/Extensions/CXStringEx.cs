using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ClangNet.Native;

namespace ClangNet
{
    // const char*
    using ConstCharPtr = IntPtr;

    /// <summary>
    /// CXString Extensions
    /// </summary>
    internal static class CXStringEx
    {
        /// <summary>
        /// Convert to Managed String
        /// </summary>
        /// <param name="string">Native Clang String</param>
        /// <param name="encoding">Default Encoding Type</param>
        /// <returns>Managed String</returns>
        internal static string ToManaged(this CXString @string, string encoding = "utf-8")
        {
            var char_ptr = LibClang.clang_getCString(@string);

            var str = char_ptr.ToManagedString(encoding);

            return str;
        }
    }
}

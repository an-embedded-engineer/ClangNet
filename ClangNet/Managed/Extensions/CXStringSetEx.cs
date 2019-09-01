using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// CXString Extensions
    /// </summary>
    internal static class CXStringSetEx
    {
        /// <summary>
        /// Convert to Managed String Array
        /// </summary>
        /// <param name="string_set">Native Clang String Set</param>
        /// <returns>Managed String</returns>
        internal static string[] ToManaged(this CXStringSet string_set)
        {
            var count = (int)string_set.Count;

            return string_set.Strings.ToNativeStructs<CXString>(count).Select(native_str => native_str.ToManaged()).ToArray();
        }
    }
}

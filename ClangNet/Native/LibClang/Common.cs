#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;

using Interp = System.Runtime.InteropServices;


namespace ClangNet.Native
{
    /// <summary>
    /// Libclang P/Invoke : Common
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// LibClang Library Name
        /// </summary>
        public const string LibraryName = "libclang";

        /// <summary>
        /// LibClang Library Calling Convention Type
        /// </summary>
        public const Interp.CallingConvention LibraryCallingConvention = Interp.CallingConvention.Cdecl;
    }
}

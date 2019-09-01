using System;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Client File
    /// </summary>
    public class ClangIndexClientFile : ClangIndexInfo
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Client File Address</param>
        internal ClangIndexClientFile(IntPtr address) : base(address)
        {
        }
    }
}

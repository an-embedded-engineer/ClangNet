using System;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Client Container
    /// </summary>
    public class ClangIndexClientContainer : ClangIndexInfo
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Client Container Address</param>
        internal ClangIndexClientContainer(IntPtr address) : base(address)
        {
        }
    }
}

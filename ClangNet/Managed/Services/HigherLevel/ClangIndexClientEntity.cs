using System;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Client Entity
    /// </summary>
    public class ClangIndexClientEntity : ClangIndexInfo
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Client Entity Address</param>
        internal ClangIndexClientEntity(IntPtr address) : base(address)
        {
        }
    }
}

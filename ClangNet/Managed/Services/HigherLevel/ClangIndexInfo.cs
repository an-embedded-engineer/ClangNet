using System;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Info
    /// </summary>
    public abstract class ClangIndexInfo : ClangObject
    {
        /// <summary>
        /// Native Clang Index Info Address
        /// </summary>
        public IntPtr Address { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Info Address</param>
        protected ClangIndexInfo(IntPtr address) : base(address)
        {
            this.Address = address;
        }
    }
}

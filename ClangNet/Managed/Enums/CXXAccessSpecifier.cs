using System;

namespace ClangNet
{
    /// <summary>
    /// C++ Access Specifier
    /// </summary>
    /// <remarks>
    /// Represents the C++ access control level to a base class for a
    /// cursor with kind <c>CX_CXXBaseSpecifier</c>.
    /// </remarks>
    public enum CxxAccessSpecifier
    {
        /// <summary>
        /// Invalid
        /// </summary>
        Invalid,

        /// <summary>
        /// Public
        /// </summary>
        Public,

        /// <summary>
        /// Protected
        /// </summary>
        Protected,

        /// <summary>
        /// Private
        /// </summary>
        Private,
    }
}

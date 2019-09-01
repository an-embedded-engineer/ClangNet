using System;

namespace ClangNet
{
    /// <summary>
    /// Symbol Role
    /// </summary>
    [Flags]
    public enum SymbolRole
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Declaration
        /// </summary>
        Declaration = 1 << 0,

        /// <summary>
        /// Definition
        /// </summary>
        Definition = 1 << 1,

        /// <summary>
        /// Reference
        /// </summary>
        Reference = 1 << 2,

        /// <summary>
        /// Read
        /// </summary>
        Read = 1 << 3,

        /// <summary>
        /// Write
        /// </summary>
        Write = 1 << 4,

        /// <summary>
        /// Call
        /// </summary>
        Call = 1 << 5,

        /// <summary>
        /// Dynamic
        /// </summary>
        Dynamic = 1 << 6,

        /// <summary>
        /// Address Of
        /// </summary>
        AddressOf = 1 << 7,

        /// <summary>
        /// Implicit
        /// </summary>
        Implicit = 1 << 8,
    }
}

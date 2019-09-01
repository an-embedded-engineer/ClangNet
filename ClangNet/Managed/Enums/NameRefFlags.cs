using System;

namespace ClangNet
{
    /// <summary>
    /// Name Reference Flags
    /// </summary>
    [Flags]
    public enum NameRefFlags
    {
        /// <summary>
        /// Want Qualifier
        /// </summary>
        /// <remarks>
        /// Include the nested-name-specifier, e.g. Foo:: in x.Foo::y, in the range.
        /// </remarks>
        WantQualifier = 0x1,

        /// <summary>
        /// Want Template Arguments
        /// </summary>
        /// <remarks>
        /// Include the explicit template arguments,
        /// e.g. \&lt;int&gt; in x.f&lt;int&gt;, in the range.
        /// </remarks>
        WantTemplateArgs = 0x2,

        /// <summary>
        /// Want Single Piece
        /// </summary>
        /// <remarks>
        /// If the name is non-contiguous, return the full spanning range.
        ///
        /// Non-contiguous names occur in Objective-C when a selector with two or more
        /// parameters is used, or in C++ when using an operator:
        /// <code>
        /// [object doSomething:here withValue:there]; // ObjC
        /// return some_vector[1]; // C++
        /// </code>
        /// </remarks>
        WantSinglePiece = 0x4,
    }
}

using System;

namespace ClangNet
{
    /// <summary>
    /// Token Kind
    /// </summary>
    public enum TokenKind
    {
        /// <summary>
        /// Punctuation
        /// </summary>
        Punctuation,

        /// <summary>
        /// Keyword
        /// </summary>
        Keyword,

        /// <summary>
        /// Identifier
        /// </summary>
        Identifier,

        /// <summary>
        /// Literal
        /// </summary>
        Literal,

        /// <summary>
        /// Comment
        /// </summary>
        Comment,
    }
}

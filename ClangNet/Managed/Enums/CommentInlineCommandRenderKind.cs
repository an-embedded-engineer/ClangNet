namespace ClangNet
{
    /// <summary>
    /// Comment Inline Command Render Kind
    /// </summary>
    /// <remarks>
    /// The most appropriate rendering mode for an inline command, chosen on
    /// command semantics in Doxygen.
    /// </remarks>
    public enum CommentInlineCommandRenderKind
    {
        /// <summary>
        /// Normal
        /// </summary>
        /// <remarks>
        /// Command argument should be rendered in a normal font.
        /// </remarks>
        Normal,

        /// <summary>
        /// Bold
        /// </summary>
        /// <remarks>
        /// Command argument should be rendered in a bold font.
        /// </remarks>
        Bold,

        /// <summary>
        /// Monospaced
        /// </summary>
        /// <remarks>
        /// Command argument should be rendered in a monospaced font.
        /// </remarks>
        Monospaced,

        /// <summary>
        /// Emphalized
        /// </summary>
        /// <remarks>
        /// Command argument should be rendered emphasized (typically italic font).
        /// </remarks>
        Emphasized,
    }
}

namespace ClangNet
{
    /// <summary>
    /// Comment Param Pass Direction
    /// </summary>
    /// <remarks>
    /// Describes parameter passing direction for \\param or \\arg command.
    /// </remarks>
    public enum CommentParamPassDirection
    {
        /// <summary>
        /// Input
        /// </summary>
        /// <remarks>
        /// The parameter is an input parameter.
        /// </remarks>
        In,
        /// <summary>
        /// Output
        /// </summary>
        /// <remarks>
        /// The parameter is an output parameter.
        /// </remarks>
        Out,
        /// <summary>
        /// Input &amp; Output
        /// </summary>
        /// <remarks>
        /// The parameter is an input and output parameter.
        /// </remarks>
        InOut,
    }
}

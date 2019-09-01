namespace ClangNet
{
    /// <summary>
    /// Comment Kind
    /// </summary>
    /// <remarks>
    /// Describes the type of the comment AST node (<c>CXComment</c>).  A comment
    /// node can be considered block content (e. g., paragraph), inline content
    /// (plain text) or neither (the root AST node).
    /// </remarks>
    public enum CommentKind
    {
        /// <summary>
        /// Null
        /// </summary>
        /// <remarks>
        /// Null comment. No AST node is constructed at the requested location
        /// because there is no text or a syntax error.
        /// </remarks>
        Null = 0,

        /// <summary>
        /// Text
        /// </summary>
        /// <remarks>
        /// Plain text. Inline content.
        /// </remarks>
        Text = 1,

        /// <summary>
        /// Inline Command
        /// </summary>
        /// <remarks>
        /// A command with word-like arguments that is considered inline content.
        ///
        /// For example: \\c command.
        /// </remarks>
        InlineCommand = 2,

        /// <summary>
        /// HTML Start Tag
        /// </summary>
        /// <remarks>
        /// HTML start tag with attributes (name-value pairs).
        /// Considered inline content.
        ///
        /// For example:
        /// &lt;br&gt; &lt;br /&gt; &lt;a href="http://example.org/"&gt;
        /// </remarks>
        HTMLStartTag = 3,

        /// <summary>
        /// HTML End Tag
        /// </summary>
        /// <remarks>
        /// HTML end tag.  Considered inline content.
        ///
        /// For example:
        /// &lt;/a&gt;
        /// </remarks>
        HTMLEndTag = 4,

        /// <summary>
        /// Paragraph
        /// </summary>
        /// <remarks>
        /// A paragraph, contains inline comment.
        /// The paragraph itself is block content.
        /// </remarks>
        Paragraph = 5,

        /// <summary>
        /// Block Command
        /// </summary>
        /// <remarks>
        /// A command that has zero or more word-like arguments (number of
        /// word-like arguments depends on command name) and a paragraph as an
        /// argument.  Block command is block content.
        ///
        /// Paragraph argument is also a child of the block command.
        ///
        /// For example: \\brief has 0 word-like arguments and a paragraph argument.
        ///
        /// AST nodes of special kinds that parser knows about (e. g., \\param
        /// command) have their own node kinds.
        /// </remarks>
        BlockCommand = 6,

        /// <summary>
        /// Parameter Command
        /// </summary>
        /// <remarks>
        /// A \\param or \\arg command that describes the function parameter
        /// (name, passing direction, description).
        ///
        /// For example: \\param [in] ParamName description.
        /// </remarks>
        ParamCommand = 7,

        /// <summary>
        ///Template Parameter Command
        /// </summary>
        /// <remarks>
        /// A \\tparam command that describes a template parameter (name and
        /// description).
        ///
        /// For example: \\tparam T description.
        /// </remarks>
        TParamCommand = 8,

        /// <summary>
        /// Verbatim Block Command
        /// </summary>
        /// <remarks>
        /// A verbatim block command (e. g., preformatted code).  Verbatim
        /// block has an opening and a closing command and contains multiple lines of
        /// text (<c>CXComment_VerbatimBlockLine</c> child nodes).
        ///
        /// For example:
        /// \\verbatim
        /// aaa
        /// \\endverbatim
        /// </remarks>
        VerbatimBlockCommand = 9,

        /// <summary>
        /// Verbatim Block Line
        /// </summary>
        /// <remarks>
        /// A line of text that is contained within a
        /// CXComment_VerbatimBlockCommand node.
        /// </remarks>
        VerbatimBlockLine = 10,

        /// <summary>
        /// Verbatim Line
        /// </summary>
        /// <remarks>
        /// A verbatim line command.  Verbatim line has an opening command,
        /// a single line of text (up to the newline after the opening command) and
        /// has no closing command.
        /// </remarks>
        VerbatimLine = 11,

        /// <summary>
        /// Full Comment
        /// </summary>
        /// <remarks>
        /// A full comment attached to a declaration, contains block content.
        /// </remarks>
        FullComment = 12,
    }
}

using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Comment
    /// </summary>
    public class ClangComment
    {
        /// <summary>
        /// Native Clang Comment
        /// </summary>
        internal CXComment Source { get; }

        /// <summary>
        /// Comment Kind
        /// </summary>
        public CommentKind Kind
        {
            get { return LibClang.clang_Comment_getKind(this.Source); }
        }

        /// <summary>
        /// Child Clang Comment Count
        /// </summary>
        public int ChildCount
        {
            get { return (int)LibClang.clang_Comment_getNumChildren(this.Source); }
        }

        /// <summary>
        /// White Space Flag
        /// </summary>
        public bool IsWhiteSpace
        {
            get { return LibClang.clang_Comment_isWhitespace(this.Source).ToBool(); }
        }

        /// <summary>
        /// Trailing New Line Exists Flag
        /// </summary>
        public bool HasTrailingNewLine
        {
            get { return LibClang.clang_InlineContentComment_hasTrailingNewline(this.Source).ToBool(); }
        }

        /// <summary>
        /// Text of Text Comment
        /// </summary>
        public string Text
        {
            get { return LibClang.clang_TextComment_getText(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Command Name of Inline Command Comment
        /// </summary>
        public string InlineCommandName
        {
            get { return LibClang.clang_InlineCommandComment_getCommandName(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Inline Command Comment Render Kind
        /// </summary>
        public CommentInlineCommandRenderKind InlineCommandRenderKind
        {
            get { return LibClang.clang_InlineCommandComment_getRenderKind(this.Source); }
        }

        /// <summary>
        /// Argument Count of Inline Command Comment
        /// </summary>
        public int InlineCommandArgumentCount
        {
            get { return (int)LibClang.clang_InlineCommandComment_getNumArgs(this.Source); }
        }

        /// <summary>
        /// Tag Name of HTML Tag Comment
        /// </summary>
        public string HtmlTagName
        {
            get { return LibClang.clang_HTMLTagComment_getTagName(this.Source).ToManaged(); }
        }

        /// <summary>
        /// HTML Start Tag Comment Self Closing Flag
        /// </summary>
        public bool IsHtmlStartTagSelfClosing
        {
            get { return LibClang.clang_HTMLStartTagComment_isSelfClosing(this.Source).ToBool(); }
        }

        /// <summary>
        /// Attribute Count of HTML Start Tag Comment
        /// </summary>
        public int HtmlStartTagAttributeCount
        {
            get { return (int)LibClang.clang_HTMLStartTag_getNumAttrs(this.Source); }
        }

        /// <summary>
        /// Command Name of Block Command Comment
        /// </summary>
        public string BlockCommandName
        {
            get { return LibClang.clang_BlockCommandComment_getCommandName(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Argument Count of Block Command Comment
        /// </summary>
        public int BlockCommandArgumentCount
        {
            get { return (int)LibClang.clang_BlockCommandComment_getNumArgs(this.Source); }
        }

        /// <summary>
        /// Paragraph Clang Comment of Block Command Comment
        /// </summary>
        public ClangComment BlockCommandParagraph
        {
            get { return LibClang.clang_BlockCommandComment_getParagraph(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Parameter Name of Parameter Command Comment
        /// </summary>
        public string ParamCommandParamName
        {
            get { return LibClang.clang_ParamCommandComment_getParamName(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Parameter Index of Parameter Command Comment Valid Flag
        /// </summary>
        public bool IsParamCommandParamIndexValid
        {
            get { return LibClang.clang_ParamCommandComment_isParamIndexValid(this.Source).ToBool(); }
        }

        /// <summary>
        /// Parameter Index of Parameter Command Comment
        /// </summary>
        public int ParamCommandParamIndex
        {
            get { return (int)LibClang.clang_ParamCommandComment_getParamIndex(this.Source); }
        }

        /// <summary>
        /// Parameter Direction of Parameter Command Comment Explicit Flag
        /// </summary>
        public bool IsParamCommandParamDirectionExplicit
        {
            get { return LibClang.clang_ParamCommandComment_isDirectionExplicit(this.Source).ToBool(); }
        }

        /// <summary>
        /// Parameter Direction of Parameter Command Comment
        /// </summary>
        public CommentParamPassDirection ParamCommandDirection
        {
            get { return LibClang.clang_ParamCommandComment_getDirection(this.Source); }
        }

        /// <summary>
        /// Parameter Name of Template Parameter Command Comment
        /// </summary>
        public string TemplateParamCommandParamName
        {
            get { return LibClang.clang_TParamCommandComment_getParamName(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Parameter Position of Template Parameter Command Comment Valid Flag
        /// </summary>
        public bool IsTemplateParamCommandParamPositionValid
        {
            get { return LibClang.clang_TParamCommandComment_isParamPositionValid(this.Source).ToBool(); }
        }

        /// <summary>
        /// Depth of Template Parameter Command Comment
        /// </summary>
        public int TemplateParamCommandDepth
        {
            get { return (int)LibClang.clang_TParamCommandComment_getDepth(this.Source); }
        }

        /// <summary>
        /// Text of Varbatim Line Comment
        /// </summary>
        public string VerbatimeLineText
        {
            get { return LibClang.clang_VerbatimLineComment_getText(this.Source).ToManaged(); }
        }

        /// <summary>
        /// HTML Tag Comment Text
        /// </summary>
        public string HtmlTagAsString
        {
            get { return LibClang.clang_HTMLTagComment_getAsString(this.Source).ToManaged(); }
        }

        /// <summary>
        /// HTML Format Full Comment
        /// </summary>
        public string FullCommentAsHtml
        {
            get { return LibClang.clang_FullComment_getAsHTML(this.Source).ToManaged(); }
        }

        /// <summary>
        /// XML Format Full Comment
        /// </summary>
        public string FullCommentAsXml
        {
            get { return LibClang.clang_FullComment_getAsXML(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Native Clang Comment</param>
        internal ClangComment(CXComment source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Get Child Clang Comment
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Child Clang Comment</returns>
        public ClangComment GetChild(int i)
        {
            return new ClangComment(LibClang.clang_Comment_getChild(this.Source, (uint)i));
        }

        /// <summary>
        /// Get Argument Text of Inline Command Comment
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Argument Text</returns>
        public string GetInlineCommandArgumentText(int i)
        {
            return LibClang.clang_InlineCommandComment_getArgText(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Attribute Name of HTML Start Tag Comment
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Attribute Name</returns>
        public string GetHtmlStartTagAttributeName(int i)
        {
            return LibClang.clang_HTMLStartTag_getAttrName(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Attribute Value of HTML Start Tag Comment
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Attribute Value</returns>
        public string GetHtmlStartTagAttributeValue(int i)
        {
            return LibClang.clang_HTMLStartTag_getAttrValue(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Argument Text of Block Command Comment
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Argument Text</returns>
        public string GetBlockCommandArgumentText(int i)
        {
            return LibClang.clang_BlockCommandComment_getArgText(this.Source, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Index of Template Parameter Command Comment
        /// </summary>
        /// <param name="depth">Depth</param>
        /// <returns>Index</returns>
        public int GetTemplateParamCommandIndex(int depth)
        {
            return (int)LibClang.clang_TParamCommandComment_getIndex(this.Source, (uint)depth);
        }
    }
}

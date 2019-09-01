#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    /// <summary>
    /// Libclang P/Invoke : Documentation
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Given a cursor that represents a documentable entity (e.g.,
        /// declaration), return the associated parsed comment as a
        /// <c>CXComment_FullComment</c> AST node.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Comment</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXComment clang_Cursor_getParsedComment(CXCursor cursor);

        /// <summary>
        /// Get Comment Kind
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <returns>Comment Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CommentKind clang_Comment_getKind(CXComment comment);

        /// <summary>
        /// Get Number of Comment Children
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <returns>Number of Comment Children</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Comment_getNumChildren(CXComment comment);

        /// <summary>
        /// Get Child Comment
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <param name="child_index">Index of Comment Children</param>
        /// <returns>Child Comment</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXComment clang_Comment_getChild(CXComment comment, uint child_index);

        /// <summary>
        /// A <c>CXComment_Paragraph</c> node is considered whitespace if it contains
        /// only <c>CXComment_Text</c> nodes that are empty or whitespace.
        ///
        /// Other AST nodes (except <c>CXComment_Paragraph</c> and <c>CXComment_Text</c>) are
        /// never considered whitespace.
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <returns>non-zero if <paramref name="comment"/> is whitespace.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_Comment_isWhitespace(CXComment comment);

        /// <summary>
        /// Check Comment has Trailing New Line
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <returns>
        /// non-zero if <paramref name="comment"/> is inline content and has a newline
        ///  immediately following it in the comment text.Newlines between paragraphs
        ///  do not count.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_InlineContentComment_hasTrailingNewline(CXComment comment);

        /// <summary>
        /// Get Text of Text Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_Text</c> AST node.</param>
        /// <returns>text contained in the AST node.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_TextComment_getText(CXComment comment);

        /// <summary>
        /// Get Command Name of Inline Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_InlineCommand</c> AST node.</param>
        /// <returns>name of the inline command.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_InlineCommandComment_getCommandName(CXComment comment);

        /// <summary>
        /// Get Render Kind of Inline Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_InlineCommand</c> AST node.</param>
        /// <returns>
        /// the most appropriate rendering mode, chosen on command
        /// semantics in Doxygen.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CommentInlineCommandRenderKind clang_InlineCommandComment_getRenderKind(CXComment comment);

        /// <summary>
        /// Get Number of Command Arguments
        /// </summary>
        /// <param name="comment">a <c>CXComment_InlineCommand</c> AST node.</param>
        /// <returns>number of command arguments.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_InlineCommandComment_getNumArgs(CXComment comment);

        /// <summary>
        /// Get Argument Text of Inline Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_InlineCommand</c> AST node.</param>
        /// <param name="arg_index">argument index (zero-based).</param>
        /// <returns>text of the specified argument.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_InlineCommandComment_getArgText(CXComment comment, uint arg_index);

        /// <summary>
        /// Get Tag Name of HTML Tag Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_HTMLStartTag</c> or <c>CXComment_HTMLEndTag</c> AST node</param>
        /// <returns>HTML tag name.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_HTMLTagComment_getTagName(CXComment comment);

        /// <summary>
        /// Check HTML Start Tag Comment is Slef Closing
        /// </summary>
        /// <param name="comment">a <c>CXComment_HTMLStartTag</c> AST node.</param>
        /// <returns>non-zero if tag is self-closing (for example, &lt;br /&gt;).</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_HTMLStartTagComment_isSelfClosing(CXComment comment);

        /// <summary>
        /// Get Number of Attributes of HTML Start Tag Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_HTMLStartTag</c> AST node.</param>
        /// <returns>number of attributes (name-value pairs) attached to the start tag.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_HTMLStartTag_getNumAttrs(CXComment comment);

        /// <summary>
        /// Get Attribute Name of HTML Start Tag Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_HTMLStartTag</c> AST node.</param>
        /// <param name="attr_index">attribute index (zero-based).</param>
        /// <returns>name of the specified attribute.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_HTMLStartTag_getAttrName(CXComment comment, uint attr_index);

        /// <summary>
        /// Get Attribute Value of HTML Start Tag Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_HTMLStartTag</c> AST node.</param>
        /// <param name="attr_index">attribute index (zero-based).</param>
        /// <returns>value of the specified attribute.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_HTMLStartTag_getAttrValue(CXComment comment, uint attr_index);

        /// <summary>
        /// Get Command Name of Block Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_BlockCommand</c> AST node.</param>
        /// <returns>name of the block command.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_BlockCommandComment_getCommandName(CXComment comment);

        /// <summary>
        /// Get Number of Arguments of Block Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_BlockCommand</c> AST node.</param>
        /// <returns>number of word-like arguments.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_BlockCommandComment_getNumArgs(CXComment comment);

        /// <summary>
        /// Get Argument Text of Block Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_BlockCommand</c> AST node.</param>
        /// <param name="arg_index">argument index (zero-based).</param>
        /// <returns>text of the specified word-like argument.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_BlockCommandComment_getArgText(CXComment comment, uint arg_index);

        /// <summary>
        /// Get Paragraph of Block Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_BlockCommand</c> or <c>CXComment_VerbatimBlockCommand</c> AST node.</param>
        /// <returns>paragraph argument of the block command.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXComment clang_BlockCommandComment_getParagraph(CXComment comment);

        /// <summary>
        /// Get Parameter Name of Param Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_ParamCommand</c> AST node.</param>
        /// <returns>parameter name.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_ParamCommandComment_getParamName(CXComment comment);

        /// <summary>
        /// Check Param Command Comment is Valid Parameter Index
        /// </summary>
        /// <param name="comment">a <c>CXComment_ParamCommand</c> AST node.</param>
        /// <returns>
        /// non-zero if the parameter that this AST node represents was found
        /// in the function prototype and <c>clang_ParamCommandComment_getParamIndex()</c>
        /// function will return a meaningful value.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_ParamCommandComment_isParamIndexValid(CXComment comment);

        /// <summary>
        /// Get Parameter Index of Param Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_ParamCommand</c> AST node.</param>
        /// <returns>
        /// zero-based parameter index in function prototype.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_ParamCommandComment_getParamIndex(CXComment comment);

        /// <summary>
        /// Check Diction of Param Command Comment is Explicit
        /// </summary>
        /// <param name="comment">a <c>CXComment_ParamCommand</c> AST node.</param>
        /// <returns>
        /// non-zero if parameter passing direction was specified explicitly in
        /// the comment.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_ParamCommandComment_isDirectionExplicit(CXComment comment);

        /// <summary>
        /// Get Diction of Param Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_ParamCommand</c> AST node.</param>
        /// <returns>parameter passing direction.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CommentParamPassDirection clang_ParamCommandComment_getDirection(CXComment comment);

        /// <summary>
        /// Get Parameter Name of Template Param Command Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_TParamCommand</c> AST node.</param>
        /// <returns>template parameter name.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_TParamCommandComment_getParamName(CXComment comment);

        /// <summary>
        /// Check Parameter Position of Template Param Command Comment is Valid
        /// </summary>
        /// <param name="comment">a <c>CXComment_TParamCommand</c> AST node.</param>
        /// <returns>
        /// non-zero if the parameter that this AST node represents was found
        /// in the template parameter list and
        /// <c>clang_TParamCommandComment_getDepth()</c> and
        /// <c>clang_TParamCommandComment_getIndex()</c> functions will return a meaningful
        /// value.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_TParamCommandComment_isParamPositionValid(CXComment comment);

        /// <summary>
        /// Get Depth of Template Param Command Comment
        ///
        /// For example,
        ///  <code>
        ///  template&lt;typename C, template&lt;typename T&gt; class TT&gt;
        ///      void test(TT&lt;int&gt; aaa);
        ///  </code>
        ///  for C and TT nesting depth is 0,
        ///  for T nesting depth is 1.
        /// </summary>
        /// <param name="comment">a <c>CXComment_TParamCommand</c> AST node.</param>
        /// <returns>zero-based nesting depth of this parameter in the template parameter list.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_TParamCommandComment_getDepth(CXComment comment);

        /// <summary>
        /// Get Index of Template Param Command Comment
        ///
        /// For example,
        /// <code>
        /// template&lt;typename C, template&lt;typename T&gt; class TT&gt;
        ///     void test(TT&lt;int&gt; aaa);
        /// </code>
        /// for C and TT nesting depth is 0, so we can ask for index at depth 0:
        /// at depth 0 C's index is 0, TT's index is 1.
        ///
        /// For T nesting depth is 1, so we can ask for index at depth 0 and 1:
        /// at depth 0 T's index is 1 (same as TT's),
        /// at depth 1 T's index is 0.
        /// </summary>
        /// <param name="comment">a <c>CXComment_TParamCommand</c> AST node.</param>
        /// <param name="depth">Depth</param>
        /// <returns>
        /// zero-based parameter index in the template parameter list at a
        /// given nesting depth.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_TParamCommandComment_getIndex(CXComment comment, uint depth);

        /// <summary>
        /// Get Text of Verbatim Block Line Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_VerbatimBlockLine</c> AST node.</param>
        /// <returns>text contained in the AST node.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_VerbatimBlockLineComment_getText(CXComment comment);

        /// <summary>
        /// Get Text of Verbatim Line Comment
        /// </summary>
        /// <param name="comment">a <c>CXComment_VerbatimLine</c> AST node.</param>
        /// <returns>text contained in the AST node.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_VerbatimLineComment_getText(CXComment comment);

        /// <summary>
        /// Convert an HTML tag AST node to string.
        /// </summary>
        /// <param name="comment">a <c>CXComment_HTMLStartTag</c> or <c>CXComment_HTMLEndTag</c> AST node.</param>
        /// <returns>string containing an HTML tag.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_HTMLTagComment_getAsString(CXComment comment);

        /// <summary>
        /// Convert a given full parsed comment to an HTML fragment.
        ///
        /// Specific details of HTML layout are subject to change.Don't try to parse
        /// this HTML back into an AST, use other APIs instead.
        ///
        /// Currently the following CSS classes are used:
        /// \li "para-brief" for \paragraph and equivalent commands;
        /// \li "para-returns" for \\returns paragraph and equivalent commands;
        /// \li "word-returns" for the "Returns" word in \\returns paragraph.
        ///
        /// Function argument documentation is rendered as a \&lt;dl\&gt; list with arguments
        /// sorted in function prototype order.CSS classes used:
        /// \li "param-name-index-NUMBER" for parameter name (\&lt;dt\&gt;);
        /// \li "param-descr-index-NUMBER" for parameter description(\&lt;dd\&gt;);
        /// \li "param-name-index-invalid" and "param-descr-index-invalid" are used if
        /// parameter index is invalid.
        ///
        /// Template parameter documentation is rendered as a \&lt;dl\&gt; list with
        /// parameters sorted in template parameter list order.CSS classes used:
        /// \li "tparam-name-index-NUMBER" for parameter name (\&lt;dt\&gt;);
        /// \li "tparam-descr-index-NUMBER" for parameter description(\&lt;dd\&gt;);
        /// \li "tparam-name-index-other" and "tparam-descr-index-other" are used for
        /// names inside template template parameters;
        /// \li "tparam-name-index-invalid" and "tparam-descr-index-invalid" are used if
        /// parameter position is invalid.
        /// </summary>
        /// <param name="comment">a <c>CXComment_FullComment</c> AST node.</param>
        /// <returns>string containing an HTML fragment.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_FullComment_getAsHTML(CXComment comment);

        /// <summary>
        /// Convert a given full parsed comment to an XML document.
        ///
        /// A Relax NG schema for the XML can be found in comment-xml-schema.rng file
        /// inside clang source tree.
        /// </summary>
        /// <param name="comment">a <c>CXComment_FullComment</c> AST node.</param>
        /// <returns>string containing an XML document.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_FullComment_getAsXML(CXComment comment);
    }
}

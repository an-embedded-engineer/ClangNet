#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // A single translation unit, which resides in an index.
    // struct CXTranslationUnitImpl*
    using CXTranslationUnit = IntPtr;

    // CXToken*
    using CXTokenPtr = IntPtr;

    // CXCursor*
    using CXCursorPtr = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Token Extraction and Manipulation
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Get the raw lexical token starting with the given location.
        /// </summary>
        /// <param name="tu">the translation unit whose text is being tokenized.</param>
        /// <param name="location">the source location with which the token starts.</param>
        /// <returns>
        /// The token starting with the given location or NULL if no such token
        /// Texist.The returned pointer must be freed with clang_disposeTokens before the
        /// Ttranslation unit is destroyed.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXTokenPtr clang_getToken(CXTranslationUnit tu, CXSourceLocation location);

        /// <summary>
        /// Determine the kind of the given token.
        /// </summary>
        /// <param name="token">Token</param>
        /// <returns>Token Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern TokenKind clang_getTokenKind(CXToken token);

        /// <summary>
        /// Determine the spelling of the given token.
        ///
        /// The spelling of a token is the textual representation of that token, e.g.,
        /// the text of an identifier or keyword.
        /// </summary>
        /// <param name="tu">the translation unit whose text is being tokenized.</param>
        /// <param name="token">Token</param>
        /// <returns>Token Spelling</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getTokenSpelling(CXTranslationUnit tu, CXToken token);

        /// <summary>
        /// Retrieve the source location of the given token.
        /// </summary>
        /// <param name="tu">the translation unit whose text is being tokenized.</param>
        /// <param name="token">Token</param>
        /// <returns>Source Location of Token</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceLocation clang_getTokenLocation(CXTranslationUnit tu, CXToken token);

        /// <summary>
        /// Retrieve a source range that covers the given token.
        /// </summary>
        /// <param name="tu">the translation unit whose text is being tokenized.</param>
        /// <param name="token">Token</param>
        /// <returns>Source Range of Token</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRange clang_getTokenExtent(CXTranslationUnit tu, CXToken token);

        /// <summary>
        /// Tokenize the source code described by the given range into raw
        /// lexical tokens.
        /// </summary>
        /// <param name="tu">the translation unit whose text is being tokenized.</param>
        /// <param name="range">
        /// Range the source range in which text should be tokenized.
        /// All of the tokens produced by tokenization will fall within this source range.
        /// </param>
        /// <param name="tokens">
        /// this pointer will be set to point to the array of tokens
        /// that occur within the given source range.The returned pointer must be
        /// freed with <c>clang_disposeTokens()</c> before the translation unit is destroyed.
        /// </param>
        /// <param name="num_tokens">it will be set to the number of tokens in the <paramref name="tokens"/> array.</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_tokenize(CXTranslationUnit tu, CXSourceRange range, out CXTokenPtr tokens, out uint num_tokens);

        /// <summary>
        /// Annotate the given set of tokens by providing cursors for each token
        /// that can be mapped to a specific entity within the abstract syntax tree.
        ///
        /// This token-annotation routine is equivalent to invoking
        /// clang_getCursor() for the source locations of each of the
        /// tokens.The cursors provided are filtered, so that only those
        /// cursors that have a direct correspondence to the token are
        /// accepted.For example, given a function call \c f(x),
        /// clang_getCursor() would provide the following cursors:
        ///
        ///   * when the cursor is over the 'f', a DeclRefExpr cursor referring to 'f'.
        ///   * when the cursor is over the '(' or the ')', a CallExpr referring to 'f'.
        ///   * when the cursor is over the 'x', a DeclRefExpr cursor referring to 'x'.
        ///
        /// Only the first and last of these cursors will occur within the
        /// annotate, since the tokens "f" and "x' directly refer to a function
        /// and a variable, respectively, but the parentheses are just a small
        /// part of the full syntax of the function call expression, which is
        /// not provided as an annotation.
        /// </summary>
        /// <param name="tu">the translation unit that owns the given tokens.</param>
        /// <param name="tokens">the set of tokens to annotate.</param>
        /// <param name="num_tokens">the number of tokens in <paramref name="tokens"/>.</param>
        /// <param name="cursors">
        /// an array of <paramref name="num_tokens"/> cursors, whose contents will be
        /// replaced with the cursors corresponding to each token.
        /// </param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_annotateTokens(CXTranslationUnit tu, CXTokenPtr tokens, uint num_tokens, ref CXCursorPtr cursors);

        /// <summary>
        /// Free the given set of tokens.
        /// </summary>
        /// <param name="tu">the translation unit that owns the given tokens.</param>
        /// <param name="tokens">the set of tokens</param>
        /// <param name="num_tokens">the number of tokens in <paramref name="tokens"/>.</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeTokens(CXTranslationUnit tu, CXTokenPtr tokens, uint num_tokens);
    }
}

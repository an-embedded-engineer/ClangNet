using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Token
    /// </summary>
    public class ClangToken
    {
        /// <summary>
        /// Native Clang Translation Unit Pointer
        /// </summary>
        internal IntPtr TranslationUnit { get; }

        /// <summary>
        /// Native Clang Token
        /// </summary>
        internal CXToken Source { get; }

        /// <summary>
        /// Token Kind
        /// </summary>
        public TokenKind Kind
        {
            get { return LibClang.clang_getTokenKind(this.Source); }
        }

        /// <summary>
        /// Token Spelling
        /// </summary>
        public string Spelling
        {
            get { return LibClang.clang_getTokenSpelling(this.TranslationUnit, this.Source).ToManaged(); }
        }

        /// <summary>
        /// Clang Source Location
        /// </summary>
        public ClangSourceLocation Location
        {
            get { return LibClang.clang_getTokenLocation(this.TranslationUnit, this.Source).ToManaged(); }
        }

        /// <summary>
        /// Clang Source Range
        /// </summary>
        public ClangSourceRange Extent
        {
            get { return LibClang.clang_getTokenExtent(this.TranslationUnit, this.Source).ToManaged(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translation_unit">Native Clang Translation Unit Pointer</param>
        /// <param name="source">Native Clang Token</param>

        internal ClangToken(IntPtr translation_unit, CXToken source)
        {
            this.TranslationUnit = translation_unit;

            this.Source = source;
        }
    }
}

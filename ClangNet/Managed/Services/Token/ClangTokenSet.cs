using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Token Set
    /// </summary>
    public class ClangTokenSet : IDisposable
    {
        /// <summary>
        /// Native Clang Translation Unit Pointer
        /// </summary>
        internal IntPtr TranslationUnit { get; }

        /// <summary>
        /// Native Clang Token Set Pointer
        /// </summary>
        internal IntPtr Source { get; }

        /// <summary>
        /// Token Count
        /// </summary>
        internal int Count { get; }

        /// <summary>
        /// Clang Token List
        /// </summary>
        public IEnumerable<ClangToken> Tokens
        {
            get { return this.Source.ToNativeStructs<CXToken>(this.Count).Select(t => t.ToManaged(this.TranslationUnit)); }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Clang Token</returns>
        public ClangToken this[int i]
        {
            get { return this.Tokens.ElementAt(i); }
        }

        /// <summary>
        /// Annotate Token Clang Cursor List
        /// </summary>
        public IEnumerable<ClangCursor> AnnotateTokens
        {
            get
            {
                var cursors = IntPtr.Zero;
                LibClang.clang_annotateTokens(this.TranslationUnit, this.Source, (uint)this.Count, ref cursors);
                return cursors.ToNativeStructs<CXCursor>(this.Count).Select(c => c.ToManaged());
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translation_unit">Native Translation Unit Pointer</param>
        /// <param name="source">Native Clang Token Set Pointer</param>
        /// <param name="count">Clang Token Count</param>
        internal ClangTokenSet(IntPtr translation_unit, IntPtr source, int count)
        {
            this.TranslationUnit = translation_unit;
            this.Source = source;
            this.Count = count;
        }

        /// <summary>
        /// Dispose Clang Token Set
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_disposeTokens(this.TranslationUnit, this.Source, (uint)this.Count);
        }
    }
}

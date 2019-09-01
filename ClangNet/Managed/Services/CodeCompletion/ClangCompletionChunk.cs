using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Completion Chunk
    /// </summary>
    public struct ClangCompletionChunk
    {
        /// <summary>
        /// Native Clang Completion Chunk Pointer
        /// </summary>
        internal IntPtr Source { get; }

        /// <summary>
        /// Index of Clang Completion Chunk
        /// </summary>
        internal uint Index { get; }

        /// <summary>
        /// Completion Chunk Kind
        /// </summary>
        public CompletionChunkKind Kind
        {
            get { return LibClang.clang_getCompletionChunkKind(this.Source, this.Index); }
        }

        /// <summary>
        /// Completion Chunk Text
        /// </summary>
        public string Text
        {
            get { return LibClang.clang_getCompletionChunkText(this.Source, this.Index).ToManaged(); }
        }

        /// <summary>
        /// Completion Chunk Clang Completion String
        /// </summary>
        public ClangCompletionString CompletionString
        {
            get { return LibClang.clang_getCompletionChunkCompletionString(this.Source, this.Index).ToManaged<ClangCompletionString>(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Native Clang Completion Chunk Pointer</param>
        /// <param name="index">Index of Clang Completion Chunk</param>
        internal ClangCompletionChunk(IntPtr source, uint index)
        {
            this.Source = source;
            this.Index = index;
        }
    }
}

using System;
using System.Linq;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    ///  Managed Clang Completion String
    /// </summary>
    public class ClangCompletionString : ClangObject
    {
        /// <summary>
        /// Clang Completion Chunk Count
        /// </summary>
        public int ChunkCount
        {
            get { return (int)LibClang.clang_getNumCompletionChunks(this.Handle); }
        }

        /// <summary>
        /// Clang Completion Chunks
        /// </summary>
        public ClangCompletionChunk[] Chunks
        {
            get { return Enumerable.Range(0, this.ChunkCount).Select(i => new ClangCompletionChunk(this.Handle, (uint)i)).ToArray(); }
        }

        /// <summary>
        /// Completion Priority
        /// </summary>
        public uint Priority
        {
            get { return LibClang.clang_getCompletionPriority(this.Handle); }
        }

        /// <summary>
        /// Completion Availability
        /// </summary>
        public AvailabilityKind Availability
        {
            get { return LibClang.clang_getCompletionAvailability(this.Handle); }
        }

        /// <summary>
        /// Completion Annotation Count
        /// </summary>
        public int AnnotationCount
        {
            get { return (int)LibClang.clang_getCompletionNumAnnotations(this.Handle); }
        }

        /// <summary>
        /// Completion Parent
        /// </summary>
        public string Parent
        {
            get { return LibClang.clang_getCompletionParent(this.Handle, IntPtr.Zero).ToManaged(); }
        }

        /// <summary>
        /// Completion Brief Comment
        /// </summary>
        public string BriefComment
        {
            get { return LibClang.clang_getCompletionBriefComment(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Completion String Pointer</param>
        internal ClangCompletionString(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get Completion Annotation
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Completion Annotation</returns>
        public string GetAnnotation(int index)
        {
            return LibClang.clang_getCompletionAnnotation(this.Handle, (uint)index).ToManaged();
        }
    }
}

using ClangNet.Native;
using System;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Unsaved File
    /// </summary>
    public struct ClangUnsavedFile
    {
        /// <summary>
        /// File Name
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Contents
        /// </summary>
        public string Contents { get; }

        /// <summary>
        /// Contents Length
        /// </summary>
        public long Length => this.Contents.Length;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">File Name</param>
        /// <param name="contents">Contents</param>
        public ClangUnsavedFile(string filename, string contents)
        {
            this.FileName = filename ?? throw new ArgumentException("File Name is null");

            this.Contents = contents ?? throw new ArgumentException("Contents is null");
        }
    }
}

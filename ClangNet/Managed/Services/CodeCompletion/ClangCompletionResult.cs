using System;
using System.Runtime.InteropServices;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Completion Result
    /// </summary>
    public class ClangCompletionResult : ClangObject
    {
        /// <summary>
        /// Native Clang Completion Result
        /// </summary>
        internal CXCompletionResult Source { get; }

        /// <summary>
        /// Cursor Kind
        /// </summary>
        public CursorKind CursorKind
        {
            get { return this.Source.CursorKind; }
        }

        /// <summary>
        /// Clang Completion String
        /// </summary>
        public ClangCompletionString CompletionString
        {
            get { return new ClangCompletionString(this.Source.CompletionString); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Completion Result Pointer</param>
        internal ClangCompletionResult(IntPtr handle) : base(handle)
        {
            this.Source = (CXCompletionResult)Marshal.PtrToStructure(this.Handle, typeof(CXCompletionResult));
        }
    }
}

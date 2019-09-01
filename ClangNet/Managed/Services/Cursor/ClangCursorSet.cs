using ClangNet.Native;
using System;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Cursor Set
    /// </summary>
    public class ClangCursorSet : ClangObject, IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Cursor Set Pointer</param>
        public ClangCursorSet(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Check Contains Cursor
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        /// <returns>Check Result</returns>
        public bool Containes(ClangCursor cursor)
        {
            return LibClang.clang_CXCursorSet_contains(this.Handle, cursor.Source).ToBool();
        }

        /// <summary>
        /// Insert Cursor
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        /// <returns>Insert Result</returns>
        public bool Insert(ClangCursor cursor)
        {
            return LibClang.clang_CXCursorSet_insert(this.Handle, cursor.Source).ToBool();
        }

        /// <summary>
        /// Dispose Clang Cursor Set
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_disposeCXCursorSet(this.Handle);
        }
    }
}

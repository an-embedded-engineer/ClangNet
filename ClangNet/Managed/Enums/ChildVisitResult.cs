using System;

namespace ClangNet
{
    /// <summary>
    /// Child Cursor Visit Result
    /// </summary>
    /// <remarks>
    /// Describes how the traversal of the children of a particular
    /// cursor should proceed after visiting a particular child cursor.
    ///
    /// A value of this enumeration type should be returned by each
    /// <c>CXCursorVisitor</c> to indicate how <c>clang_visitChildren()</c> proceed.
    /// </remarks>
    public enum ChildVisitResult
    {
        /// <summary>
        /// Break
        /// </summary>
        /// <remarks>
        /// Terminates the cursor traversal.
        /// </remarks>
        Break,

        /// <summary>
        /// Continue
        /// </summary>
        /// <remarks>
        /// Continues the cursor traversal with the next sibling of
        /// the cursor just visited, without visiting its children.
        /// </remarks>
        Continue,

        /// <summary>
        /// Recurse
        /// </summary>
        /// <remarks>
        /// Recursively traverse the children of this cursor, using
        /// the same visitor and client data.
        /// </remarks>
        Recurse,
    }
}

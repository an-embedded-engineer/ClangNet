using System;

namespace ClangNet
{
    /// <summary>
    /// Find Result
    /// </summary>
    public enum FindResult
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <remarks>
        /// Function returned successfully.
        /// </remarks>
        Success = 0,

        /// <summary>
        /// Invalid
        /// </summary>
        /// <remarks>
        /// One of the parameters was invalid for the function.
        /// </remarks>
        Invalid = 1,

        /// <summary>
        /// Visit Break
        /// </summary>
        /// <remarks>
        /// The function was terminated by a callback
        /// (e.g. it returned <c>CXVisit_Break</c>)
        /// </remarks>
        VisitBreak = 2,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Cursor Exception Specification Kind
    /// </summary>
    /// <remarks>
    /// Describes the exception specification of a cursor.
    /// A negative value indicates that the cursor is not a function declaration.
    /// </remarks>
    public enum CursorExceptionSpecificationKind
    {
        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// The cursor has no exception specification.
        /// </remarks>
        None,

        /// <summary>
        /// Dynamic None
        /// </summary>
        /// <remarks>
        /// The cursor has exception specification throw()
        /// </remarks>
        DynamicNone,

        /// <summary>
        /// Dynamic
        /// </summary>
        /// <remarks>
        /// The cursor has exception specification throw(T1, T2)
        /// </remarks>
        Dynamic,

        /// <summary>
        /// MS Any
        /// </summary>
        /// <remarks>
        /// The cursor has exception specification throw(...).
        /// </remarks>
        MSAny,

        /// <summary>
        /// Basic Noexcept
        /// </summary>
        /// <remarks>
        /// The cursor has exception specification basic noexcept.
        /// </remarks>
        BasicNoexcept,

        /// <summary>
        /// Computed Noexcet
        /// </summary>
        /// <remarks>
        /// The cursor has exception specification computed noexcept.
        /// </remarks>
        ComputedNoexcept,

        /// <summary>
        /// Unevaluated
        /// </summary>
        /// <remarks>
        /// The exception specification has not yet been evaluated.
        /// </remarks>
        Unevaluated,
    }
}

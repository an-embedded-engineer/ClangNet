using System;

namespace ClangNet
{
    /// <summary>
    /// Reference Qualifier Kind
    /// </summary>
    /// <remarks>
    /// The kind of C++0x ref-qualifier associated with a function type,
    /// which determines whether a member function's "this" object can be an
    /// lvalue, rvalue, or neither.
    /// </remarks>
    public enum RefQualifierKind
    {
        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// No ref-qualifier was provided.
        /// </remarks>
        None = 0,

        /// <summary>
        /// L Value
        /// </summary>
        /// <remarks>
        /// An lvalue ref-qualifier was provided (<c>&amp;</c>).
        /// </remarks>
        LValue,

        /// <summary>
        /// R Value
        /// </summary>
        /// <remarks>
        /// An rvalue ref-qualifier was provided (<c>&amp;&amp;</c>).
        /// </remarks>
        RValue,
    }
}

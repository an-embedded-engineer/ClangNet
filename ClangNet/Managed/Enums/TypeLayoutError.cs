using System;

namespace ClangNet
{
    /// <summary>
    /// Type Layout Error
    /// </summary>
    public enum TypeLayoutError
    {
        /// <summary>
        /// Invalid
        /// </summary>
        /// <remarks>
        /// Type is of kind CXType_Invalid.
        /// </remarks>
        Invalid = -1,

        /// <summary>
        /// Incomplete
        /// </summary>
        /// <remarks>
        /// The type is an incomplete Type.
        /// </remarks>
        Incomplete = -2,

        /// <summary>
        /// Dependent
        /// </summary>
        /// <remarks>
        /// The type is a dependent Type.
        /// </remarks>
        Dependent = -3,

        /// <summary>
        /// Not Constant Size
        /// </summary>
        /// <remarks>
        /// The type is not a constant size type.
        /// </remarks>
        NotConstantSize = -4,

        /// <summary>
        /// Invalid Field Name
        /// </summary>
        /// <remarks>
        /// The Field name is not valid for this record.
        /// </remarks>
        InvalidFieldName = -5,

        /// <summary>
        /// Undeduced
        /// </summary>
        /// <remarks>
        /// The type is undeduced.
        /// </remarks>
        Undeduced = -6,
    }
}

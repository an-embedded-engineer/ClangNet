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
        Invalid = -1,

        /// <summary>
        /// Incomplete
        /// </summary>
        Incomplete = -2,

        /// <summary>
        /// Dependent
        /// </summary>
        Dependent = -3,

        /// <summary>
        /// Not Constant Size
        /// </summary>
        NotConstantSize = -4,

        /// <summary>
        /// Invalid Field Name
        /// </summary>
        InvalidFieldName = -5,
    }
}

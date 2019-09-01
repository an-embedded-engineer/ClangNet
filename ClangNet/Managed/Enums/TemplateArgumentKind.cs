using System;

namespace ClangNet
{
    /// <summary>
    /// Template Argument Kind
    /// </summary>
    public enum TemplateArgumentKind
    {
        /// <summary>
        /// Null
        /// </summary>
        Null,

        /// <summary>
        /// Type
        /// </summary>
        Type,

        /// <summary>
        /// Declaration
        /// </summary>
        Declaration,

        /// <summary>
        /// Null Pointer
        /// </summary>
        NullPtr,

        /// <summary>
        /// Integral
        /// </summary>
        Integral,

        /// <summary>
        /// Template
        /// </summary>
        Template,

        /// <summary>
        /// Template Expansion
        /// </summary>
        TemplateExpansion,

        /// <summary>
        /// Expression
        /// </summary>
        Expression,

        /// <summary>
        /// Pack
        /// </summary>
        Pack,

        /// <summary>
        /// Invalid
        /// </summary>
        Invalid,
    }
}

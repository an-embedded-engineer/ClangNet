using System;

namespace ClangNet
{
    /// <summary>
    /// Index Entity C++ Template Kind
    /// </summary>
    public enum IndexEntityCxxTemplateKind
    {
        /// <summary>
        /// Non Template
        /// </summary>
        NonTemplate = 0,

        /// <summary>
        /// Template
        /// </summary>
        Template = 1,

        /// <summary>
        /// Template Partial Specialization
        /// </summary>
        TemplatePartialSpecialization = 2,

        /// <summary>
        /// Template Specialization
        /// </summary>
        TemplateSpecialization = 3,
    }
}

using System;

namespace ClangNet
{
    /// <summary>
    /// Index Attribute Kind
    /// </summary>
    public enum IndexAttributeKind
    {
        /// <summary>
        /// Unexposed
        /// </summary>
        Unexposed = 0,

        /// <summary>
        /// IBAction
        /// </summary>
        IBAction = 1,

        /// <summary>
        /// IBOutlet
        /// </summary>
        IBOutlet = 2,

        /// <summary>
        /// IBOutlet Collection
        /// </summary>
        IBOutletCollection = 3,
    }
}

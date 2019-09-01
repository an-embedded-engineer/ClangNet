using System;

namespace ClangNet
{
    /// <summary>
    /// Index Objective-C Container Kind
    /// </summary>
    public enum IndexObjCContainerKind
    {
        /// <summary>
        /// Forwared Reference
        /// </summary>
        ForwardRef = 0,

        /// <summary>
        /// Interface
        /// </summary>
        Interface = 1,

        /// <summary>
        /// Implementation
        /// </summary>
        Implementation = 2,
    }
}

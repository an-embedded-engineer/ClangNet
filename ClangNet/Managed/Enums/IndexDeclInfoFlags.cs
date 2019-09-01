using System;

namespace ClangNet
{
    /// <summary>
    /// Index Declaration Info Flags
    /// </summary>
    [Flags]
    public enum IndexDeclInfoFlags
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Skipped
        /// </summary>
        Skipped = 0x1,
    }
}

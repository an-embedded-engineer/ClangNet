using System;

namespace ClangNet
{
    /// <summary>
    /// Objective-C Declaration Qualifier Kind
    /// </summary>
    [Flags]
    public enum ObjCDeclQualifierKind
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0x00,

        /// <summary>
        /// In
        /// </summary>
        In = 0x01,

        /// <summary>
        /// In / Out
        /// </summary>
        InOut = 0x02,

        /// <summary>
        /// Out
        /// </summary>
        Out = 0x04,

        /// <summary>
        /// By Copy
        /// </summary>
        ByCopy = 0x08,

        /// <summary>
        /// By Reference
        /// </summary>
        ByRef = 0x10,

        /// <summary>
        /// One Way
        /// </summary>
        OneWay = 0x20,
    }
}

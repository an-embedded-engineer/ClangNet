using System;

namespace ClangNet
{
    /// <summary>
    /// Objective-C Property Attribute Kind
    /// </summary>
    [Flags]
    public enum ObjCPropertyAttrKind
    {
        /// <summary>
        /// No Attribute
        /// </summary>
        NoAttr = 0x00,

        /// <summary>
        /// Read Only
        /// </summary>
        ReadOnly = 0x01,

        /// <summary>
        /// Getter
        /// </summary>
        Getter = 0x02,

        /// <summary>
        /// Assign
        /// </summary>
        Assign = 0x04,

        /// <summary>
        /// Read / Write
        /// </summary>
        ReadWrite = 0x08,

        /// <summary>
        /// Retain
        /// </summary>
        Retain = 0x10,

        /// <summary>
        /// Copy
        /// </summary>
        Copy = 0x20,

        /// <summary>
        /// Non Atomic
        /// </summary>
        NonAtomic = 0x40,

        /// <summary>
        /// Setter
        /// </summary>
        Setter = 0x80,

        /// <summary>
        /// Atomic
        /// </summary>
        Atomic = 0x100,

        /// <summary>
        /// Weak
        /// </summary>
        Weak = 0x200,

        /// <summary>
        /// Strong
        /// </summary>
        Strong = 0x400,

        /// <summary>
        /// Unsafe Unretained
        /// </summary>
        UnsafeUnretained = 0x800,

        /// <summary>
        /// Class
        /// </summary>
        Class = 0x1000,
    }
}

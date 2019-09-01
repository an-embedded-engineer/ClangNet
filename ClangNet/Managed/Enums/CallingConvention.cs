using System;

namespace ClangNet
{
    /// <summary>
    /// Calling Convention Type
    /// </summary>
    /// <remarks>
    /// Describes the calling convention of a function type
    /// </remarks>
    public enum CallingConvention
    {
        /// <summary>
        /// Default
        /// </summary>
        Default = 0,
        /// <summary>
        /// C
        /// </summary>
        C = 1,
        /// <summary>
        /// x86 Standart Call
        /// </summary>
        X86StdCall = 2,
        /// <summary>
        /// x86 Fast Call
        /// </summary>
        X86FastCall = 3,
        /// <summary>
        /// x86 This Call
        /// </summary>
        X86ThisCall = 4,
        /// <summary>
        /// x86 Pascal
        /// </summary>
        X86Pascal = 5,
        /// <summary>
        /// AAPCS
        /// </summary>
        AAPCS = 6,
        /// <summary>
        /// AAPCS VFP
        /// </summary>
        AAPCSVfp = 7,
        /// <summary>
        /// x86 Register Call
        /// </summary>
        X86RegCall = 8,
        /// <summary>
        /// Intel OCL BICC
        /// </summary>
        IntelOclBicc = 9,
        /// <summary>
        /// Windows 64
        /// </summary>
        Win64 = 10,
        /// <summary>
        /// x86_64 Windows 64
        /// </summary>
        X86_64Win64 = Win64,
        /// <summary>
        /// x86_64 SystemV
        /// </summary>
        X86_64SysV = 11,
        /// <summary>
        /// x86 Vector Call
        /// </summary>
        X86VectorCall = 12,
        /// <summary>
        /// Swift
        /// </summary>
        Swift = 13,
        /// <summary>
        /// Preserve Most
        /// </summary>
        PreserveMost = 14,
        /// <summary>
        /// Preserve All
        /// </summary>
        PreserveAll = 15,
        /// <summary>
        /// AArch64 Vector Call
        /// </summary>
        AArch64VectorCall = 16,
        /// <summary>
        /// Invalid
        /// </summary>
        Invalid = 100,
        /// <summary>
        /// Unexposed
        /// </summary>
        Unexposed = 200,
    }
}

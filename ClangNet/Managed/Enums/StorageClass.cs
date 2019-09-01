using System;

namespace ClangNet
{
    /// <summary>
    /// Storage Class
    /// </summary>
    public enum StorageClass
    {
        /// <summary>
        /// Invalid
        /// </summary>
        Invalid,

        /// <summary>
        /// None
        /// </summary>
        None,

        /// <summary>
        /// Extern
        /// </summary>
        Extern,

        /// <summary>
        /// Static
        /// </summary>
        Static,

        /// <summary>
        /// Private Extern
        /// </summary>
        PrivateExtern,

        /// <summary>
        /// OpenCL Work Group Local
        /// </summary>
        OpenCLWorkGroupLocal,

        /// <summary>
        /// Auto
        /// </summary>
        Auto,

        /// <summary>
        /// Register
        /// </summary>
        Register,
    }
}

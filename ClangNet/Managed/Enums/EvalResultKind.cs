using System;

namespace ClangNet
{
    /// <summary>
    /// Evaluation Result Kind
    /// </summary>
    public enum EvalResultKind
    {
        /// <summary>
        /// Integer
        /// </summary>
        Int = 1,

        /// <summary>
        /// Float
        /// </summary>
        Float = 2,

        /// <summary>
        /// Objective-C String Literal
        /// </summary>
        ObjCStrLiteral = 3,

        /// <summary>
        /// String Literal
        /// </summary>
        StrLiteral = 4,

        /// <summary>
        /// String
        /// </summary>
        Str = 5,

        /// <summary>
        /// Other
        /// </summary>
        Other = 6,

        /// <summary>
        /// Unexposed
        /// </summary>
        UnExposed = 0,
    }
}

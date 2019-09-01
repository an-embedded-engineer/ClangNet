using System;

namespace ClangNet
{
    /// <summary>
    /// Libclang Error Code
    /// </summary>
    /// <remarks>
    /// Error codes returned by libclang routines.
    /// Zero (<c>Success</c>) is the only error code indicating success.
    /// Other error codes, including not yet assigned non-zero values, indicate errors.
    /// </remarks>
    public enum ErrorCode
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <remarks>
        /// No error.
        /// </remarks>
        Success = 0,

        /// <summary>
        /// Failure
        /// </summary>
        /// <remarks>
        /// A generic error code, no further details are available.
        /// Errors of this kind can get their own specific error codes in future
        /// libclang versions.
        /// </remarks>
        Failure = 1,

        /// <summary>
        /// Crashed
        /// </summary>
        /// <remarks>
        /// libclang crashed while performing the requested operation.
        /// </remarks>
        Crashed = 2,

        /// <summary>
        /// Invalid Arguments
        /// </summary>
        /// <remarks>
        /// The function detected that the arguments violate the function contract.
        /// </remarks>
        InvalidArguments = 3,

        /// <summary>
        /// AST Read Error
        /// </summary>
        /// <remarks>
        /// An AST deserialization error has occurred.
        /// </remarks>
        ASTReadError = 4,
    }
}

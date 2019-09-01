using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Load Diagnostic Eerror
    /// </summary>
    /// <remarks>
    /// Describes the kind of error that occurred (if any) in a call to
    /// <c>clang_loadDiagnostics()</c>.
    /// </remarks>
    public enum LoadDiagError
    {
        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// Indicates that no error occurred.
        /// </remarks>
        None = 0,

        /// <summary>
        /// Unknown
        /// </summary>
        /// <remarks>
        /// Indicates that an unknown error occurred while attempting to
        /// deserialize diagnostics.
        /// </remarks>
        Unknown = 1,

        /// <summary>
        /// Cannot Load
        /// </summary>
        /// <remarks>
        /// Indicates that the file containing the serialized diagnostics
        /// could not be opened.
        /// </remarks>
        CannotLoad = 2,

        /// <summary>
        /// Invalid File
        /// </summary>
        /// <remarks>
        /// Indicates that the serialized diagnostics file is invalid or corrupt.
        /// </remarks>
        InvalidFile = 3,
    }
}

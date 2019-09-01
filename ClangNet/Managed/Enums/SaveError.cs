using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Save Error
    /// </summary>
    /// <remarks>
    /// Describes the kind of error that occurred (if any) in a call to
    /// <c>clang_saveTranslationUnit()</c>.
    /// </remarks>
    public enum SaveError
    {
        /// <summary>
        /// None
        /// </summary>
        /// <remarks>
        /// Indicates that no error occurred while saving a translation unit.
        /// </remarks>
        None = 0,

        /// <summary>
        /// Unknown
        /// </summary>
        /// <remarks>
        /// Indicates that an unknown error occurred while attempting to save the file.
        ///
        /// This error typically indicates that file I/O failed when attempting to write the file.
        /// </remarks>
        Unknown = 1,

        /// <summary>
        /// Translation Errors
        /// </summary>
        /// <remarks>
        /// Indicates that errors during translation prevented this attempt
        /// to save the translation unit.
        ///
        /// Errors that prevent the translation unit from being saved can be
        /// extracted using <c>clang_getNumDiagnostics()</c> and <c>clang_getDiagnostic()</c>.
        /// </remarks>
        TranslationErrors = 2,

        /// <summary>
        /// Invalid Translation Unit
        /// </summary>
        /// <remarks>
        /// Indicates that the translation unit to be saved was somehow invalid (e.g., NULL).
        /// </remarks>
        InvalidTU = 3,
    }
}

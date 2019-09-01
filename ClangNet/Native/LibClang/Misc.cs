#pragma warning disable IDE1006

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace ClangNet.Native
{
    // A single translation unit, which resides in an index.
    // struct CXTranslationUnitImpl*
    using CXTranslationUnit = IntPtr;

    // Opaque pointer representing client data that will be passed through
    // to various callbacks and visitors.
    // void*
    using CXClientData = IntPtr;

    // A particular source file that is part of a translation unit.
    // void*
    using CXFile = IntPtr;

    // CXSourceLocation*
    using CXSourceLocationPtr = IntPtr;

    // void*
    using CXEvalResult = IntPtr;

    /// <summary>
    /// Visitor invoked for each file in a translation unit
    /// (used with <c>clang_getInclusions()</c>).
    ///
    /// This visitor function will be invoked by <c>clang_getInclusions()</c> for each
    /// file included(either at the top-level or by #include directives) within
    /// a translation unit.The first argument is the file being included, and
    /// the second and third arguments provide the inclusion stack.  The
    /// array is sorted in order of immediate inclusion.  For example,
    /// the first element refers to the location that included 'included_file'.
    /// </summary>
    /// <param name="included_file">Include File</param>
    /// <param name="inclusion_stack">Inclusion Stack</param>
    /// <param name="include_len">Include Length</param>
    /// <param name="client_data">Client Data</param>
    [UnmanagedFunctionPointer(LibClang.LibraryCallingConvention)]
    delegate void CXInclusionVisitor(CXFile included_file, CXSourceLocationPtr inclusion_stack, uint include_len, CXClientData client_data);

    /// <summary>
    /// Libclang P/Invoke : Miscellaneous Utility
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Return a version string, suitable for showing to a user, but not
        /// intended to be parsed (the format is not guaranteed to be stable).
        /// </summary>
        /// <returns>Version String</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getClangVersion();

        /// <summary>
        /// Enable/disable crash recovery.
        /// </summary>
        /// <param name="is_enabled">
        /// Flag to indicate if crash recovery is enabled.
        /// A non-zero value enables crash recovery, while 0 disables it.
        /// </param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_toggleCrashRecovery(uint is_enabled);

        /// <summary>
        /// Visit the set of preprocessor inclusions in a translation unit.
        /// The visitor function is called with the provided data for every included
        /// file.This does not include headers included by the PCH file(unless one
        /// is inspecting the inclusions in the PCH file itself).
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <param name="visitor">Inclusion Visitor</param>
        /// <param name="client_data">Client Data</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_getInclusions(CXTranslationUnit tu, CXInclusionVisitor visitor, CXClientData client_data);

        /// <summary>
        /// If cursor is a statement declaration tries to evaluate the
        /// statement and if its variable, tries to evaluate its initializer,
        /// into its corresponding type.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <returns>Evaluation Result</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXEvalResult clang_Cursor_Evaluate(CXCursor cursor);

        /// <summary>
        /// Returns the kind of the evaluated result.
        /// </summary>
        /// <param name="eval_result">Evaluation Result</param>
        /// <returns>Evaluation Result Kind</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern EvalResultKind clang_EvalResult_getKind(CXEvalResult eval_result);

        /// <summary>
        /// Returns the evaluation result as integer if the kind is Int.
        /// </summary>
        /// <param name="eval_result">Evaluation Result</param>
        /// <returns>Integer Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern int clang_EvalResult_getAsInt(CXEvalResult eval_result);

        /// <summary>
        /// Returns the evaluation result as a long long integer if the
        /// kind is Int. This prevents overflows that may happen if the result is
        /// returned with <c>clang_EvalResult_getAsInt()</c>.
        /// </summary>
        /// <param name="eval_result">Evaluation Result</param>
        /// <returns>Long Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern long clang_EvalResult_getAsLongLong(CXEvalResult eval_result);

        /// <summary>
        /// Returns a non-zero value if the kind is Int and the evaluation
        /// result resulted in an unsigned integer.
        /// </summary>
        /// <param name="eval_result">Evaluation Result</param>
        /// <returns>Unsigned Integer Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_EvalResult_isUnsignedInt(CXEvalResult eval_result);

        /// <summary>
        /// Returns the evaluation result as an unsigned integer if
        /// the kind is Int and <c>clang_EvalResult_isUnsignedInt</c> is non-zero.
        /// </summary>
        /// <param name="eval_result">Evaluation Result</param>
        /// <returns>Unsigned Long Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern ulong clang_EvalResult_getAsUnsigned(CXEvalResult eval_result);

        /// <summary>
        /// Returns the evaluation result as double if the kind is double.
        /// </summary>
        /// <param name="eval_result">Evaluation Result</param>
        /// <returns>Double Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern double clang_EvalResult_getAsDouble(CXEvalResult eval_result);

        /// <summary>
        /// Returns the evaluation result as a constant string if the
        /// kind is other than Int or float. User must not free this pointer,
        /// instead call <c>clang_EvalResult_dispose()</c> on the <c>CXEvalResult</c> returned
        /// by <c>clang_Cursor_Evaluate()</c>.
        /// </summary>
        /// <param name="eval_result">Evaluation Result</param>
        /// <returns>String Value</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern string clang_EvalResult_getAsStr(CXEvalResult eval_result);

        /// <summary>
        /// Disposes the created Eval memory.
        /// </summary>
        /// <param name="eval_result">Evaluation Result</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_EvalResult_dispose(CXEvalResult eval_result);
    }
}

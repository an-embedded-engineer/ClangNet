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

    // A single diagnostic, containing the diagnostic's severity,
    // location, text, source ranges, and fix-it hints.
    // void*
    using CXDiagnostic = IntPtr;

    // A group of CXDiagnostics.
    // void*
    using CXDiagnosticSet = IntPtr;

    /// <summary>
    /// Libclang P/Invoke : Diagnostics Reporting
    /// </summary>
    internal static partial class LibClang
    {
        /// <summary>
        /// Determine the number of diagnostics in a CXDiagnosticSet.
        /// </summary>
        /// <param name="diags">Diagnostic Set</param>
        /// <returns>Number of Diagnostics</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getNumDiagnosticsInSet(CXDiagnosticSet diags);

        /// <summary>
        /// Retrieve a diagnostic associated with the given CXDiagnosticSet.
        /// </summary>
        /// <param name="diags">the CXDiagnosticSet to query.</param>
        /// <param name="index">the zero-based diagnostic number to retrieve.</param>
        /// <returns>
        /// the requested diagnostic. This diagnostic must be freed
        /// via a call to <c>clang_disposeDiagnostic()</c>.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXDiagnostic clang_getDiagnosticInSet(CXDiagnosticSet diags, uint index);

        /// <summary>
        ///  Deserialize a set of diagnostics from a Clang diagnostics bitcode file.
        /// </summary>
        /// <param name="file">The name of the file to deserialize.</param>
        /// <param name="error">
        /// A pointer to a enum value recording if there was a problem
        /// deserializing the diagnostics.
        /// </param>
        /// <param name="error_string">
        /// A pointer to a CXString for recording the error string
        /// if the file was not successfully loaded.
        /// </param>
        /// <returns>
        /// A loaded CXDiagnosticSet if successful, and NULL otherwise.
        /// These diagnostics should be released using <c>clang_disposeDiagnosticSet()</c>.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXDiagnosticSet clang_loadDiagnostics(string file, out LoadDiagError error, out CXString error_string);

        /// <summary>
        /// Release a CXDiagnosticSet and all of its contained diagnostics.
        /// </summary>
        /// <param name="diags">Diagnostic Set</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeDiagnosticSet(CXDiagnosticSet diags);

        /// <summary>
        /// Retrieve the child diagnostics of a CXDiagnostic.
        ///
        /// This CXDiagnosticSet does not need to be released by
        /// <c>clang_disposeDiagnosticSet()</c>.
        /// </summary>
        /// <param name="diagnostic">Diagnostic Set</param>
        /// <returns>Diagnostic Set</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXDiagnosticSet clang_getChildDiagnostics(CXDiagnostic diagnostic);

        /// <summary>
        /// Determine the number of diagnostics produced for the given
        /// translation unit.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>Number of Diagnostics</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getNumDiagnostics(CXTranslationUnit tu);

        /// <summary>
        /// Retrieve a diagnostic associated with the given translation unit.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <param name="index">Index of Diagnostics</param>
        /// <returns>Diagnostic</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXDiagnostic clang_getDiagnostic(CXTranslationUnit tu, uint index);

        /// <summary>
        /// Retrieve the complete set of diagnostics associated with a translation unit.
        /// </summary>
        /// <param name="tu">Translation Unit</param>
        /// <returns>Diagnostic Set</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXDiagnosticSet clang_getDiagnosticSetFromTU(CXTranslationUnit tu);

        /// <summary>
        /// Destroy a diagnostic.
        /// </summary>
        /// <param name="diagnostic">Diagnostic</param>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern void clang_disposeDiagnostic(CXDiagnostic diagnostic);

        /// <summary>
        /// Format the given diagnostic in a manner that is suitable for display.
        ///
        /// This routine will format the given diagnostic to a string, rendering
        /// the diagnostic according to the various options given.The
        /// <c>clang_defaultDiagnosticDisplayOptions()</c> function returns the set of
        /// options that most closely mimics the behavior of the clang compiler.
        /// </summary>
        /// <param name="diagnostic">The diagnostic to print.</param>
        /// <param name="options">
        /// A set of options that control the diagnostic display,
        /// created by combining <c>CXDiagnosticDisplayOptions</c> values.
        /// </param>
        /// <returns>A new string containing for formatted diagnostic.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_formatDiagnostic(CXDiagnostic diagnostic, DiagnosticDisplayOptions options);

        /// <summary>
        /// Retrieve the set of display options most similar to the
        /// default behavior of the clang compiler.
        /// </summary>
        /// <returns>
        /// A set of display options suitable for use with <c>clang_formatDiagnostic()</c>.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern DiagnosticDisplayOptions clang_defaultDiagnosticDisplayOptions();

        /// <summary>
        /// Determine the severity of the given diagnostic.
        /// </summary>
        /// <param name="diagnostic">Diagnostic</param>
        /// <returns>Diagnostic Severity</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern DiagnosticSeverity clang_getDiagnosticSeverity(CXDiagnostic diagnostic);

        /// <summary>
        /// Retrieve the source location of the given diagnostic.
        ///
        /// This location is where Clang would print the caret('^') when
        /// displaying the diagnostic on the command line.
        /// </summary>
        /// <param name="diagnostic">Diagnostic</param>
        /// <returns>Diagnostic Source Location</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceLocation clang_getDiagnosticLocation(CXDiagnostic diagnostic);

        /// <summary>
        /// Retrieve the text of the given diagnostic.
        /// </summary>
        /// <param name="diagnostic">Diagnostic</param>
        /// <returns>Diagnostic Spelling</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getDiagnosticSpelling(CXDiagnostic diagnostic);

        /// <summary>
        /// Retrieve the name of the command-line option that enabled this diagnostic.
        /// </summary>
        /// <param name="diagnostic">The diagnostic to be queried.</param>
        /// <param name="disable">If non-NULL, will be set to the option that disables this diagnostic (if any).</param>
        /// <returns>
        /// A string that contains the command-line option used to enable this
        /// warning, such as "-Wconversion" or "-pedantic".
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getDiagnosticOption(CXDiagnostic diagnostic, out CXString disable);

        /// <summary>
        /// Retrieve the category number for this diagnostic.
        ///
        /// Diagnostics can be categorized into groups along with other, related
        /// diagnostics(e.g., diagnostics under the same warning flag). This routine
        /// retrieves the category number for the given diagnostic.
        /// </summary>
        /// <param name="diagnostic">Diagnostic</param>
        /// <returns>
        /// The number of the category that contains this diagnostic, or zero
        /// if this diagnostic is uncategorized.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getDiagnosticCategory(CXDiagnostic diagnostic);

        /// <summary>
        /// Retrieve the name of a particular diagnostic category.
        /// This is now deprecated.
        /// Use <c>clang_getDiagnosticCategoryText()</c> instead.
        /// </summary>
        /// <param name="category">
        /// A diagnostic category number, as returned by
        /// <c>clang_getDiagnosticCategory()</c>.
        /// </param>
        /// <returns>The name of the given diagnostic category.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getDiagnosticCategoryName(uint category);

        /// <summary>
        /// Retrieve the diagnostic category text for a given diagnostic.
        /// </summary>
        /// <param name="diagnostic">Diagnostic</param>
        /// <returns>The text of the given diagnostic category.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getDiagnosticCategoryText(CXDiagnostic diagnostic);

        /// <summary>
        /// Determine the number of source ranges associated with the given diagnostic.
        /// </summary>
        /// <param name="diagnostic">Diagnostic</param>
        /// <returns>Number of Diagnostic Source Ranges</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getDiagnosticNumRanges(CXDiagnostic diagnostic);

        /// <summary>
        /// Retrieve a source range associated with the diagnostic.
        ///
        /// A diagnostic's source ranges highlight important elements in the source
        /// code.On the command line, Clang displays source ranges by
        /// underlining them with '~' characters.
        /// </summary>
        /// <param name="diagnostic">the diagnostic whose range is being extracted.</param>
        /// <param name="range">the zero-based index specifying which range to</param>
        /// <returns>the requested source range.</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXSourceRange clang_getDiagnosticRange(CXDiagnostic diagnostic, uint range);

        /// <summary>
        /// Determine the number of fix-it hints associated with the
        /// given diagnostic.
        /// </summary>
        /// <param name="diagnostic">Diagnostic</param>
        /// <returns>Number of Diagnostic Fix-It Hints</returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern uint clang_getDiagnosticNumFixIts(CXDiagnostic diagnostic);

        /// <summary>
        /// Retrieve the replacement information for a given fix-it.
        ///
        /// Fix-its are described in terms of a source range whose contents
        /// should be replaced by a string. This approach generalizes over
        /// three kinds of operations: removal of source code(the range covers
        /// the code to be removed and the replacement string is empty),
        /// replacement of source code(the range covers the code to be
        /// replaced and the replacement string provides the new code), and
        /// insertion(both the start and end of the range point at the
        /// insertion location, and the replacement string provides the text to
        /// insert).
        /// </summary>
        /// <param name="diagnostic">The diagnostic whose fix-its are being queried.</param>
        /// <param name="fix_it">The zero-based index of the fix-it.</param>
        /// <param name="replacement_range">
        /// ReplacementRange The source range whose contents will be
        /// replaced with the returned replacement string. Note that source
        /// ranges are half-open ranges[a, b), so the source code should be
        /// replaced from a and up to(but not including) b.
        /// </param>
        /// <returns>
        /// A string containing text that should be replace the source
        /// code indicated by the <paramref name="replacement_range"/>.
        /// </returns>
        [DllImport(LibraryName, CallingConvention = LibraryCallingConvention)]
        internal static extern CXString clang_getDiagnosticFixIt(CXDiagnostic diagnostic, uint fix_it, out CXSourceRange replacement_range);
    }
}

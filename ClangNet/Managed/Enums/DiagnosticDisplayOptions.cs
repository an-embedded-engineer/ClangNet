using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// Diagnostic Display Options
    /// </summary>
    /// <remarks>
    /// Options to control the display of diagnostics.
    /// The values in this enum are meant to be combined to customize the
    /// behavior of <c>clang_formatDiagnostic()</c>.
    /// </remarks>
    public enum DiagnosticDisplayOptions
    {
        /// <summary>
        /// Display Source Location
        /// </summary>
        /// <remarks>
        /// Display the source-location information where the diagnostic was located.
        /// When set, diagnostics will be prefixed by the file, line, and
        /// (optionally) column to which the diagnostic refers.
        ///
        /// For example,
        /// <code>
        /// test.c:28: warning: extra tokens at end of #endif directive
        /// </code>
        ///
        /// This option corresponds to the clang flag <c>-fshow-source-location</c>.
        /// </remarks>
        DisplaySourceLocation = 0x01,

        /// <summary>
        /// Display Column
        /// </summary>
        /// <remarks>
        /// If displaying the source-location information of the
        /// diagnostic, also include the column number.
        /// This option corresponds to the clang flag <c>-fshow-column</c>.
        /// </remarks>
        DisplayColumn = 0x02,

        /// <summary>
        /// Display Source Ranged
        /// </summary>
        /// <remarks>
        /// If displaying the source-location information of the
        /// diagnostic, also include information about source ranges in a
        /// machine-parsable format.
        /// This option corresponds to the clang flag
        /// <c>-fdiagnostics-print-source-range-info</c>.
        /// </remarks>
        DisplaySourceRanges = 0x04,

        /// <summary>
        /// Display Option
        /// </summary>
        /// <remarks>
        /// Display the option name associated with this diagnostic, if any.
        /// The option name displayed (e.g., <c>-Wconversio</c>n) will be placed in brackets
        /// after the diagnostic text. This option corresponds to the clang flag
        /// <c>-fdiagnostics-show-option</c>.
        /// </remarks>
        DisplayOption = 0x08,

        /// <summary>
        /// Display Category ID
        /// </summary>
        /// <remarks>
        /// Display the category number associated with this diagnostic, if any.
        /// The category number is displayed within brackets after the diagnostic text.
        /// This option corresponds to the clang flag
        /// <c>-fdiagnostics-show-category=id</c>.
        /// </remarks>
        DisplayCategoryId = 0x10,

        /// <summary>
        /// Display Category Name
        /// </summary>
        /// <remarks>
        /// Display the category name associated with this diagnostic, if any.
        /// The category name is displayed within brackets after the diagnostic text.
        /// This option corresponds to the clang flag
        /// <c>-fdiagnostics-show-category=name</c>.
        /// </remarks>
        DisplayCategoryName = 0x20,
    }
}
